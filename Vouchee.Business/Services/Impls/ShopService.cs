using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Shop;
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
    public class ShopService : IShopService
    {
        private readonly IShopRepo _shopRepo;
        private readonly IMapper _mapper;

        public ShopService(IMapper mapper, IShopRepo shopRepo)
        {
            _shopRepo = shopRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<ShopResponse>> CreateShop(CreateShopRequest request)
        {
            try
            {
                var entity = _mapper.Map<Shop>(request);
                await _shopRepo.AddAsync(_mapper.Map<Shop>(request));
                await _shopRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ShopResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_shopRepo) ;
            }
            return new ResponseResult<ShopResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ShopResponse>> DeleteShop(Guid id)
        {
            try
            {
                var existedShop = _shopRepo.GetByIdAsync(id).Result;

                if (existedShop == null)
                {
                    return new ResponseResult<ShopResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _shopRepo.Delete(existedShop);
                await _shopRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<ShopResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_shopRepo) ;
            }

            return new ResponseResult<ShopResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ShopResponse>> GetShop(Guid id)
        {
            ShopResponse result;

            try
            {
                result = _mapper.Map<ShopResponse>(_shopRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<ShopResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<ShopResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_shopRepo) ;
            }

            return new ResponseResult<ShopResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<ShopResponse>> GetShops(ShopFilter request, PagingRequest paging)
        {
            (int, IQueryable<ShopResponse>) result;
            try
            {
                var query = _shopRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<ShopResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<ShopResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<ShopResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<ShopResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<ShopResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_shopRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<ShopResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<ShopResponse>> UpdateShop(UpdateShopRequest request, Guid id)
        {
            try
            {
                var existedShop = _shopRepo.GetByIdAsync(id).Result;

                if (existedShop == null)
                {
                    return new ResponseResult<ShopResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newShop = _mapper.Map<Shop>(request);

                _shopRepo.Update(newShop);
                await _shopRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ShopResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_shopRepo) ;
            }

            return new ResponseResult<ShopResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
