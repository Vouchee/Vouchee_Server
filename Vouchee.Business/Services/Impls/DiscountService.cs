using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Discount;
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

namespace Vouchee.Business.Services.Impls
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepo _discountRepo;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDiscountRepo discountRepo)
        {
            _discountRepo = discountRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<DiscountResponse>> CreateDiscount(CreateDiscountRequest request)
        {
            try
            {
                var entity = _mapper.Map<Discount>(request);
                await _discountRepo.AddAsync(_mapper.Map<Discount>(request));
                await _discountRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<DiscountResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_discountRepo) ;
            }
            return new ResponseResult<DiscountResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<DiscountResponse>> DeleteDiscount(Guid id)
        {
            try
            {
                var existedDiscount = _discountRepo.GetByIdAsync(id).Result;

                if (existedDiscount == null)
                {
                    return new ResponseResult<DiscountResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _discountRepo.Delete(existedDiscount);
                await _discountRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<DiscountResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_discountRepo) ;
            }

            return new ResponseResult<DiscountResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<DiscountResponse>> GetDiscount(Guid id)
        {
            DiscountResponse result;

            try
            {
                result = _mapper.Map<DiscountResponse>(_discountRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<DiscountResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<DiscountResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_discountRepo) ;
            }

            return new ResponseResult<DiscountResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<DiscountResponse>> GetDiscounts(DiscountFilter request, PagingRequest paging)
        {
            (int, IQueryable<DiscountResponse>) result;
            try
            {
                result = _discountRepo.GetAllAsync().Result
                    .ProjectTo<DiscountResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<DiscountResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<DiscountResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<DiscountResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_discountRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<DiscountResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<DiscountResponse>> UpdateDiscount(UpdateDiscountRequest request, Guid id)
        {
            try
            {
                var existedDiscount = _discountRepo.GetByIdAsync(id).Result;

                if (existedDiscount == null)
                {
                    return new ResponseResult<DiscountResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newDiscount = _mapper.Map<Discount>(request);

                _discountRepo.Update(newDiscount);
                await _discountRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<DiscountResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_discountRepo) ;
            }

            return new ResponseResult<DiscountResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
