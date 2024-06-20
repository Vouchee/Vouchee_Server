using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Tag;
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
    public class TagService : ITagService
    {
        private readonly ITagRepo _tagRepo;
        private readonly IMapper _mapper;

        public TagService(IMapper mapper, ITagRepo tagRepo)
        {
            _tagRepo = tagRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<TagResponse>> CreateTag(CreateTagRequest request)
        {
            try
            {
                var entity = _mapper.Map<Tag>(request);
                await _tagRepo.AddAsync(_mapper.Map<Tag>(request));
                await _tagRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_tagRepo) ;
            }
            return new ResponseResult<TagResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<TagResponse>> DeleteTag(Guid id)
        {
            try
            {
                var existedTag = _tagRepo.GetByIdAsync(id).Result;

                if (existedTag == null)
                {
                    return new ResponseResult<TagResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _tagRepo.Delete(existedTag);
                await _tagRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<TagResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_tagRepo) ;
            }

            return new ResponseResult<TagResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<TagResponse>> GetTag(Guid id)
        {
            TagResponse result;

            try
            {
                result = _mapper.Map<TagResponse>(_tagRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<TagResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_tagRepo) ;
            }

            return new ResponseResult<TagResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<TagResponse>> GetTags(TagFilter request, PagingRequest paging)
        {
            (int, IQueryable<TagResponse>) result;
            try
            {
                var query = _tagRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<TagResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<TagResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<TagResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<TagResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<TagResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_tagRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<TagResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<TagResponse>> UpdateTag(UpdateTagRequest request, Guid id)
        {
            try
            {
                var existedTag = _tagRepo.GetByIdAsync(id).Result;

                if (existedTag == null)
                {
                    return new ResponseResult<TagResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newTag = _mapper.Map<Tag>(request);

                _tagRepo.Update(newTag);
                await _tagRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TagResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_tagRepo) ;
            }

            return new ResponseResult<TagResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
