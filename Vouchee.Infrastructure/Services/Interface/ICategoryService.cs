using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Infrastructure.FilterModels;
using Vouchee.Infrastructure.RequestModels.Category;
using Vouchee.Infrastructure.RequestModels.Helpers;
using Vouchee.Infrastructure.WebResponse;
using Vouchee.Infrastructure.WebResponse.Helpers;
using static Vouchee.Infrastructure.WebResponse.Helpers.DynamicModelResponse;

namespace Vouchee.Infrastructure.Services.Interface
{
    public interface ICategoryService
    {
        public Task<ResponseResult<CategoryResponse>> GetCategory(Guid id);
        public Task<ResponseResult<CategoryResponse>> UpdateCategory(UpdateCategoryRequest request, Guid id);
        public Task<ResponseResult<CategoryResponse>> DeleteCategory(Guid id);
        public Task<ResponseResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request);
        public Task<DynamicModelsResponse<CategoryResponse>> GetCategorys(CategoryFilter request, PagingRequest paging);
    }
}
