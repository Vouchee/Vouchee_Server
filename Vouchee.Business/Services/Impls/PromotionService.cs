using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Promotion;
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
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepo _promotionRepo;
        private readonly IMapper _mapper;

        public PromotionService(IMapper mapper, IPromotionRepo promotionRepo)
        {
            _promotionRepo = promotionRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<PromotionResponse>> CreatePromotion(CreatePromotionRequest request)
        {
            try
            {
                var entity = _mapper.Map<Promotion>(request);
                await _promotionRepo.AddAsync(_mapper.Map<Promotion>(request));
                await _promotionRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PromotionResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_promotionRepo) ;
            }
            return new ResponseResult<PromotionResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<PromotionResponse>> DeletePromotion(Guid id)
        {
            try
            {
                var existedPromotion = _promotionRepo.GetByIdAsync(id).Result;

                if (existedPromotion == null)
                {
                    return new ResponseResult<PromotionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _promotionRepo.Delete(existedPromotion);
                await _promotionRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<PromotionResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_promotionRepo) ;
            }

            return new ResponseResult<PromotionResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<PromotionResponse>> GetPromotion(Guid id)
        {
            PromotionResponse result;

            try
            {
                result = _mapper.Map<PromotionResponse>(_promotionRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<PromotionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<PromotionResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_promotionRepo) ;
            }

            return new ResponseResult<PromotionResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<PromotionResponse>> GetPromotions(PromotionFilter request, PagingRequest paging)
        {
            (int, IQueryable<PromotionResponse>) result;
            try
            {
                result = _promotionRepo.GetAllAsync().Result
                    .ProjectTo<PromotionResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<PromotionResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<PromotionResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<PromotionResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_promotionRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<PromotionResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<PromotionResponse>> UpdatePromotion(UpdatePromotionRequest request, Guid id)
        {
            try
            {
                var existedPromotion = _promotionRepo.GetByIdAsync(id).Result;

                if (existedPromotion == null)
                {
                    return new ResponseResult<PromotionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newPromotion = _mapper.Map<Promotion>(request);

                _promotionRepo.Update(newPromotion);
                await _promotionRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<PromotionResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_promotionRepo) ;
            }

            return new ResponseResult<PromotionResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
