using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Rating;
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
using Vouchee.Data.Repositories.Impls;

namespace Vouchee.Business.Services.Impls
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _ratingRepo;
        private readonly IMapper _mapper;

        public RatingService(IMapper mapper, IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<RatingResponse>> CreateRating(CreateRatingRequest request)
        {
            try
            {
                var entity = _mapper.Map<Rating>(request);
                await _ratingRepo.AddAsync(_mapper.Map<Rating>(request));
                await _ratingRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RatingResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_ratingRepo) ;
            }
            return new ResponseResult<RatingResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<RatingResponse>> DeleteRating(Guid id)
        {
            try
            {
                var existedRating = _ratingRepo.GetByIdAsync(id).Result;

                if (existedRating == null)
                {
                    return new ResponseResult<RatingResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _ratingRepo.Delete(existedRating);
                await _ratingRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<RatingResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_ratingRepo) ;
            }

            return new ResponseResult<RatingResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<RatingResponse>> GetRating(Guid id)
        {
            RatingResponse result;

            try
            {
                result = _mapper.Map<RatingResponse>(_ratingRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<RatingResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<RatingResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_ratingRepo) ;
            }

            return new ResponseResult<RatingResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<RatingResponse>> GetRatings(RatingFilter request, PagingRequest paging)
        {
            (int, IQueryable<RatingResponse>) result;
            try
            {
                var query = _ratingRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<RatingResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<RatingResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<RatingResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (!result.Item2.Any())
                {
                    return new DynamicModelResponse.DynamicModelsResponse<RatingResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<RatingResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_ratingRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<RatingResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<RatingResponse>> UpdateRating(UpdateRatingRequest request, Guid id)
        {
            try
            {
                var existedRating = _ratingRepo.GetByIdAsync(id).Result;

                if (existedRating == null)
                {
                    return new ResponseResult<RatingResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newRating = _mapper.Map<Rating>(request);

                _ratingRepo.Update(newRating);
                await _ratingRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<RatingResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_ratingRepo) ;
            }

            return new ResponseResult<RatingResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
