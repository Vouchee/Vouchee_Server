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
using Microsoft.AspNetCore.Identity;

namespace Vouchee.Business.Services.Impls
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, IUserRepo userRepo, UserManager<User> userManager)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<ResponseResult<UserResponse>> CreateUser(CreateUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<User>(request);
                await _userRepo.AddAsync(_mapper.Map<User>(request), request.UserPassword);
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
                var user = await _userRepo.GetByIdAsync(id);
                result = _mapper.Map<UserResponse>(user);

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
                var users = await _userRepo.GetAllAsync();
                result = users
                    .AsQueryable()
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
        public async Task<ResponseResult<UserResponse>> UpdatePasswordAsync(Guid uId, string pass)
        {
            var user = await _userRepo.GetFirstOrDefaultAsync(u => u.Id == uId);

            if (user == null)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }

            // Remove the existing password if it exists
            var removePasswordResult = await _userRepo.RemovePass(user);
            if (!removePasswordResult.Succeeded)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.DELETE_INFO_SUCCESS,
                    Result = false
                };
            }

            // Add the new password
            var addPasswordResult = await _userRepo.CreatePass(user, pass);
            if (!addPasswordResult.Succeeded)
            {
                return new ResponseResult<UserResponse>()
                {
                    Message = StringConstant.CREATE_INFO_SUCCESS,
                    Result = false
                };
            }

            return new ResponseResult<UserResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
       
    }