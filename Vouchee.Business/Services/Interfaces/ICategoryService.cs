using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.RequestModels.Category;
using Vouchee.Business.FilterModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ResponseResult<CategoryResponse>> GetCategory(Guid id);
        public Task<ResponseResult<CategoryResponse>> UpdateCategory(UpdateCategoryRequest request, Guid id);
        public Task<ResponseResult<CategoryResponse>> DeleteCategory(Guid id);
        public Task<ResponseResult<CategoryResponse>> CreateCategory(CreateCategoryRequest request);
        public Task<DynamicModelsResponse<CategoryResponse>> GetCategories(CategoryFilter request, PagingRequest paging);
    }
}
