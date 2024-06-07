using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Domain.Entities;
using Vouchee.Infrastructure.Repositories.Interface;
using Vouchee.Infrastructure.WebResponse;
using Vouchee.Infrastructure.WebResponse.Helpers;
using Vouchee.Infrastructure.RequestModels.Category;
using Vouchee.Domain.Constaints;
using AutoMapper.QueryableExtensions;
using Vouchee.Infrastructure.Helpers;
using Vouchee.Infrastructure.Services.Interface;
using Vouchee.Infrastructure.FilterModels;
using Vouchee.Infrastructure.RequestModels.Helpers;

namespace Vouchee.Infrastructure.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;
		private readonly IMapper mapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			this.categoryRepository = categoryRepository;
			this.mapper = mapper;
		}

		public async Task<ResponseResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request)
		{
			CategoryResponse value;
			try
			{
				value = mapper.Map<CategoryResponse>(await categoryRepository.InsertAsync(mapper.Map<Category>(request)));
			}
			catch (Exception ex)
			{
				return new ResponseResult<CategoryResponse>()
				{
					Message = Constraints.CREATE_INFO_FAILED,
					Result = false
				};
			}
			finally
			{
				lock (categoryRepository) ;
			}

			return new ResponseResult<CategoryResponse>()
			{
				Message = Constraints.CREATE_INFO_SUCCESS,
				Result = true,
				Value = value
			};
		}

		public async Task<ResponseResult<CategoryResponse>> DeleteCategory(Guid id)
		{
			try
			{
				var existedCategory = await categoryRepository.GetByIdAsync(id);

				if (existedCategory == null)
				{
					return new ResponseResult<CategoryResponse>()
					{
						Message = Constraints.NOT_FOUND_INFO,
						Result = false
					};
				}

				await categoryRepository.HardDeleteAsync(id);
			}
			catch (Exception ex)
			{
				return new ResponseResult<CategoryResponse>()
				{
					Message = Constraints.DELETE_INFO_FAILED,
					Result = false
				};
			}
			finally
			{
				lock (categoryRepository) ;
			}

			return new ResponseResult<CategoryResponse>()
			{
				Message = Constraints.DELETE_INFO_SUCCESS,
				Result = true
			};
		}

		public async Task<ResponseResult<CategoryResponse>> GetCategory(Guid id)
		{
			CategoryResponse value;

			try
			{
				value = mapper.Map<CategoryResponse>(await categoryRepository.GetByIdAsync(id));

				if (value == null)
				{
					return new ResponseResult<CategoryResponse>()
					{
						Message = Constraints.NOT_FOUND_INFO,
					};
				}
			}
			catch (Exception ex)
			{
				return new ResponseResult<CategoryResponse>()
				{
					Message = Constraints.LOAD_INFO_FAILED,
				};
			}
			finally
			{
				lock (categoryRepository) ;
			}

			return new ResponseResult<CategoryResponse>()
			{
				Value = value,
			};
		}

		public async Task<DynamicModelResponse.DynamicModelsResponse<CategoryResponse>> GetCategorys(CategoryFilter request, PagingRequest paging)
		{
			(int, IQueryable<CategoryResponse>) result;
			try
			{
				var list = await categoryRepository.GetAllAsync();
				result = list.ProjectTo<CategoryResponse>(mapper.ConfigurationProvider)
							.DynamicFilter(mapper.Map<CategoryResponse>(request))
							.PagingIQueryable(paging.Page, paging.PageSize, Constraints.LimitPaging, Constraints.DefaultPaging);

				if (result.Item2.ToList().Count() == 0)
				{
					return new DynamicModelResponse.DynamicModelsResponse<CategoryResponse>()
					{
						Message = Constraints.EMPTY_INFO,
					};
				}

			}
			catch (Exception ex)
			{
				return new DynamicModelResponse.DynamicModelsResponse<CategoryResponse>()
				{
					Message = Constraints.LOAD_INFO_FAILED,
				};
			}
			finally
			{
				lock (categoryRepository) ;
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
			CategoryResponse categoryResponse;
			try
			{
				var existedCategory = await categoryRepository.GetByIdAsync(id);

				if (UpdateCategory == null)
				{
					return new ResponseResult<CategoryResponse>()
					{
						Message = Constraints.NOT_FOUND_INFO,
						Result = false
					};
				}

				categoryResponse = mapper.Map<CategoryResponse>(await categoryRepository.UpdateByIdAsync(mapper.Map<Category>(request), id));
			}
			catch (Exception ex)
			{
				return new ResponseResult<CategoryResponse>()
				{
					Message = Constraints.UPDATE_INFO_FAILED,
					Result = false
				};
			}
			finally
			{
				lock (categoryRepository) ;
			}

			return new ResponseResult<CategoryResponse>()
			{
				Message = Constraints.UPDATE_INFO_SUCCESS,
				Result = true,
				Value = categoryResponse
			};
		}
	}
}
