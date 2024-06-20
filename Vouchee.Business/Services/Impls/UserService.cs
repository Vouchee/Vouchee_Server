using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.User;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Models.Entities;
using AutoMapper;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Models.Constants;
using AutoMapper.QueryableExtensions;
using Vouchee.Business.Helpers;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Vouchee.Business.Services.Impls
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public UserService(IMapper mapper, IUserRepo userRepo,IConfiguration configuration)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = configuration;
        }


        public async Task<ResponseResult<UserResponse>> CreateUser(CreateUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<User>(request);
                await _userRepo.AddAsync(_mapper.Map<User>(request));
                await _userRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_userRepo) ;
            }
            return new ResponseResult<UserResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<UserResponse>> DeleteUser(Guid id)
        {
            try
            {
                var existedUser = _userRepo.GetByIdAsync(id).Result;

                if (existedUser == null)
                {
                    return new ResponseResult<UserResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _userRepo.Delete(existedUser);
                await _userRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_userRepo) ;
            }

            return new ResponseResult<UserResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<UserResponse>> GetUser(Guid id)
        {
            UserResponse result;

            try
            {
                result = _mapper.Map<UserResponse>(_userRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<UserResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_userRepo) ;
            }

            return new ResponseResult<UserResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<UserResponse>> GetUsers(UserFilter request, PagingRequest paging)
        {
            (int, IQueryable<UserResponse>) result;
            try
            {
                result = _userRepo.GetAllAsync().Result
                    .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<UserResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<UserResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<UserResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_userRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<UserResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<UserResponse>> UpdateUser(UpdateUserRequest request, Guid id)
        {
            try
            {
                var existedUser = _userRepo.GetByIdAsync(id).Result;

                if (existedUser == null)
                {
                    return new ResponseResult<UserResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newUser = _mapper.Map<User>(request);

                _userRepo.Update(newUser);
                await _userRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_userRepo) ;
            }

            return new ResponseResult<UserResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<LoginRequest>> Login(LoginRequest login)
        {
            var user = await _userRepo.GetFirstOrDefaultAsync(u => u.UserName ==  login.UserName);
            if (!IsValidPassword(login.UserPassword))
            {
                return new ResponseResult<LoginRequest>()
                {
                    Message = StringConstant.PASSWORD_INVALIDATE,
                    Result = false
                };
            }
            if (user != null)
            {
                if (!user.UserPassword.Equals(login.UserPassword))
                {
                    return new ResponseResult<LoginRequest>()
                    {
                        Message = StringConstant.WRONG_PASSWORD,
                        Result = false
                    };
                }
                var token = GenerateJSONWebToken(login);
                return new ResponseResult<LoginRequest>()
                {
                    Message = StringConstant.LOGIN_SUCCESS,
                    Result = true,
                    Response = token,
                };
            }
            return new ResponseResult<LoginRequest>()
            {
                Message = StringConstant.EMPTY_INFO,
                Result = false
            };
        }
        public bool IsValidPassword(string password)
        {
            var hasMinimum6Chars = new Regex(@".{6,}");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasSpecialChar = new Regex(@"[!@#$%^&*(),.?""{}|<>]");

            return hasMinimum6Chars.IsMatch(password) && hasUpperChar.IsMatch(password) && hasSpecialChar.IsMatch(password);
        }
        private string GenerateJSONWebToken(LoginRequest userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsList = new List<Claim>();

            foreach (RoleResponse role in userInfo.Roles)
            {
                claimsList.Add(new Claim(ClaimTypes.Role, role.RoleName));
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claimsList,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
