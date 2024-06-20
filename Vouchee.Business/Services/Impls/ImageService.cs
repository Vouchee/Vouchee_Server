using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Image;
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
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public ImageService(IMapper mapper, IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<ImageResponse>> CreateImage(CreateImageRequest request)
        {
            try
            {
                var entity = _mapper.Map<Image>(request);
                await _imageRepo.AddAsync(_mapper.Map<Image>(request));
                await _imageRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ImageResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_imageRepo) ;
            }
            return new ResponseResult<ImageResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ImageResponse>> DeleteImage(Guid id)
        {
            try
            {
                var existedImage = _imageRepo.GetByIdAsync(id).Result;

                if (existedImage == null)
                {
                    return new ResponseResult<ImageResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _imageRepo.Delete(existedImage);
                await _imageRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<ImageResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_imageRepo) ;
            }

            return new ResponseResult<ImageResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ImageResponse>> GetImage(Guid id)
        {
            ImageResponse result;

            try
            {
                result = _mapper.Map<ImageResponse>(_imageRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<ImageResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<ImageResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_imageRepo) ;
            }

            return new ResponseResult<ImageResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<ImageResponse>> GetImages(ImageFilter request, PagingRequest paging)
        {
            (int, IQueryable<ImageResponse>) result;
            try
            {
                var query = _imageRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<ImageResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<ImageResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<ImageResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<ImageResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<ImageResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_imageRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<ImageResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<ImageResponse>> UpdateImage(UpdateImageRequest request, Guid id)
        {
            try
            {
                var existedImage = _imageRepo.GetByIdAsync(id).Result;

                if (existedImage == null)
                {
                    return new ResponseResult<ImageResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newImage = _mapper.Map<Image>(request);

                _imageRepo.Update(newImage);
                await _imageRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ImageResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_imageRepo) ;
            }

            return new ResponseResult<ImageResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
