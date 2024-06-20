using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Role;
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
using Vouchee.Data.Repositories.Repos;

namespace Vouchee.Business.Services.Impls
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper, IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<RoleResponse>> CreateRole(CreateRoleRequest request)
        {
            try
            {
                var entity = _mapper.Map<Role>(request);
                await _roleRepo.AddAsync(_mapper.Map<Role>(request));
                await _roleRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoleResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_roleRepo) ;
            }
            return new ResponseResult<RoleResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<RoleResponse>> DeleteRole(Guid id)
        {
            try
            {
                var existedRole = _roleRepo.GetByIdAsync(id).Result;

                if (existedRole == null)
                {
                    return new ResponseResult<RoleResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _roleRepo.Delete(existedRole);
                await _roleRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<RoleResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_roleRepo) ;
            }

            return new ResponseResult<RoleResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<RoleResponse>> GetRole(Guid id)
        {
            RoleResponse result;

            try
            {
                result = _mapper.Map<RoleResponse>(_roleRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<RoleResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoleResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_roleRepo) ;
            }

            return new ResponseResult<RoleResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<RoleResponse>> GetRoles(RoleFilter request, PagingRequest paging)
        {
            (int, IQueryable<RoleResponse>) result;
            try
            {
                var query = _roleRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<RoleResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<RoleResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<RoleResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<RoleResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<RoleResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_roleRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<RoleResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<RoleResponse>> UpdateRole(UpdateRoleRequest request, Guid id)
        {
            try
            {
                var existedRole = _roleRepo.GetByIdAsync(id).Result;

                if (existedRole == null)
                {
                    return new ResponseResult<RoleResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newRole = _mapper.Map<Role>(request);

                _roleRepo.Update(newRole);
                await _roleRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RoleResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_roleRepo) ;
            }

            return new ResponseResult<RoleResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
