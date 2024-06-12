using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Location;
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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepo _locationRepo;
        private readonly IMapper _mapper;

        public LocationService(IMapper mapper, ILocationRepo locationRepo)
        {
            _locationRepo = locationRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<LocationResponse>> CreateLocation(CreateLocationRequest request)
        {
            try
            {
                var entity = _mapper.Map<Location>(request);
                await _locationRepo.AddAsync(_mapper.Map<Location>(request));
                await _locationRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_locationRepo) ;
            }
            return new ResponseResult<LocationResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<LocationResponse>> DeleteLocation(Guid id)
        {
            try
            {
                var existedLocation = _locationRepo.GetByIdAsync(id).Result;

                if (existedLocation == null)
                {
                    return new ResponseResult<LocationResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _locationRepo.Delete(existedLocation);
                await _locationRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_locationRepo) ;
            }

            return new ResponseResult<LocationResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<LocationResponse>> GetLocation(Guid id)
        {
            LocationResponse result;

            try
            {
                result = _mapper.Map<LocationResponse>(_locationRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<LocationResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_locationRepo) ;
            }

            return new ResponseResult<LocationResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<LocationResponse>> GetLocations(LocationFilter request, PagingRequest paging)
        {
            (int, IQueryable<LocationResponse>) result;
            try
            {
                result = _locationRepo.GetAllAsync().Result
                    .ProjectTo<LocationResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<LocationResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<LocationResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<LocationResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_locationRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<LocationResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<LocationResponse>> UpdateLocation(UpdateLocationRequest request, Guid id)
        {
            try
            {
                var existedLocation = _locationRepo.GetByIdAsync(id).Result;

                if (existedLocation == null)
                {
                    return new ResponseResult<LocationResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newLocation = _mapper.Map<Location>(request);

                _locationRepo.Update(newLocation);
                await _locationRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<LocationResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_locationRepo) ;
            }

            return new ResponseResult<LocationResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
