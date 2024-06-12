using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

       
        public async Task<ResponseResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request)
        {
            try
            {
                var entity = _mapper.Map<Category>(request);
                await _categoryRepo.AddAsync(_mapper.Map<Category>(request));
                await _categoryRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_categoryRepo) ;
            }
            return new ResponseResult<CategoryResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<CategoryResponse>> DeleteCategory(Guid id)
        {
            try
            {
                var existedCategory = _categoryRepo.GetByIdAsync(id).Result;

                if (existedCategory == null)
                {
                    return new ResponseResult<CategoryResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _categoryRepo.Delete(existedCategory);
                await _categoryRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_categoryRepo) ;
            }

            return new ResponseResult<CategoryResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<CategoryResponse>> GetCategory(Guid id)
        {
            CategoryResponse result;

            try
            {
                result = _mapper.Map<CategoryResponse>(_categoryRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<CategoryResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_categoryRepo) ;
            }

            return new ResponseResult<CategoryResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<CategoryResponse>> GetCategories(CategoryFilter request, PagingRequest paging)
        {
            (int, IQueryable<CategoryResponse>) result;
            try
            {
                var p = _categoryRepo.GetAllAsync().Result;
                result = _categoryRepo.GetAllAsync().Result
                    .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<CategoryResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<CategoryResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<CategoryResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_categoryRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<CategoryResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<CategoryResponse>> UpdateCategory(UpdateCategoryRequest request, Guid id)
        {
            try
            {
                var existedCategory = _categoryRepo.GetByIdAsync(id).Result;

                if (existedCategory == null)
                {
                    return new ResponseResult<CategoryResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                existedCategory = _mapper.Map<Category>(request);

                _categoryRepo.Update(existedCategory);
                await _categoryRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CategoryResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_categoryRepo) ;
            }

            return new ResponseResult<CategoryResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
