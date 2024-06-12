using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Category;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<ResponseResult<CategoryResponse>> GetCategory(Guid id)
        {
            return await _service.GetCategory(id);
        }

        [HttpGet("GetListCategory")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<CategoryResponse>> GetListCategory([FromQuery] CategoryFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetCategories(filter, paging);
        }

        [HttpPost("CreateCategory")]
        public async Task<ResponseResult<CategoryResponse>> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            return await _service.CreateCategory(request);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<ResponseResult<CategoryResponse>> UpdateCategory([FromBody] UpdateCategoryRequest request, Guid id)
        {
            return await _service.UpdateCategory(request, id);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ResponseResult<CategoryResponse>> DeleteCategory(Guid id)
        {
            return await _service.DeleteCategory(id);
        }
    }
}
