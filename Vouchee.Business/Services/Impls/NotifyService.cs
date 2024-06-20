using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Notify;
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
    public class NotifyService : INotifyService
    {
        private readonly INotifyRepo _notityRepo;
        private readonly IMapper _mapper;

        public NotifyService(IMapper mapper, INotifyRepo notityRepo)
        {
            _notityRepo = notityRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<NotifyResponse>> CreateNotify(CreateNotifyRequest request)
        {
            try
            {
                var entity = _mapper.Map<Notify>(request);
                await _notityRepo.AddAsync(_mapper.Map<Notify>(request));
                await _notityRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<NotifyResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_notityRepo) ;
            }
            return new ResponseResult<NotifyResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<NotifyResponse>> DeleteNotify(Guid id)
        {
            try
            {
                var existedNotify = _notityRepo.GetByIdAsync(id).Result;

                if (existedNotify == null)
                {
                    return new ResponseResult<NotifyResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _notityRepo.Delete(existedNotify);
                await _notityRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<NotifyResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_notityRepo) ;
            }

            return new ResponseResult<NotifyResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<NotifyResponse>> GetNotify(Guid id)
        {
            NotifyResponse result;

            try
            {
                result = _mapper.Map<NotifyResponse>(_notityRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<NotifyResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<NotifyResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_notityRepo) ;
            }

            return new ResponseResult<NotifyResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<NotifyResponse>> GetNotifies(NotifyFilter request, PagingRequest paging)
        {
            (int, IQueryable<NotifyResponse>) result;
            try
            {
                var query = _notityRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<NotifyResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<NotifyResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<NotifyResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<NotifyResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<NotifyResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_notityRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<NotifyResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<NotifyResponse>> UpdateNotify(UpdateNotifyRequest request, Guid id)
        {
            try
            {
                var existedNotify = _notityRepo.GetByIdAsync(id).Result;

                if (existedNotify == null)
                {
                    return new ResponseResult<NotifyResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newNotify = _mapper.Map<Notify>(request);

                _notityRepo.Update(newNotify);
                await _notityRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<NotifyResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_notityRepo) ;
            }

            return new ResponseResult<NotifyResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
