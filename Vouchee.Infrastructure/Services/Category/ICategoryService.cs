using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Infrastructure.FilterModels;
using Vouchee.Infrastructure.RequestModels.Helpers;
using Vouchee.Infrastructure.WebRequests.Category;
using Vouchee.Infrastructure.WebResponse;
using Vouchee.Infrastructure.WebResponse.Helpers;
using static Vouchee.Infrastructure.WebResponse.Helpers.DynamicModelResponse;

namespace Vouchee.Infrastructure.Services.Category
{
	public interface ICategoryService
	{
		public ResponseResult<CategoryResponse> GetCategory(int id);
		public ResponseResult<ICollection<CategoryResponse>> CategoryStatistics();
		public ResponseResult<CategoryResponse> UpdateCategory(UpdateCategoryRequest request, int id);
		public ResponseResult<CategoryResponse> DeleteCategory(int id);
		public ResponseResult<CategoryResponse> CreateCategory(CreateCategoryRequest request);
		public DynamicModelsResponse<CategoryResponse> GetCategorys(CategoryFilter request, PagingRequest paging);
	}
}
