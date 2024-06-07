using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Application.FilterModels;
using Vouchee.Application.RequestModels.Helpers;
using Vouchee.Application.Services.Category;
using Vouchee.Application.WebRequests.Category;
using Vouchee.Application.WebResponse.Helpers;
using Vouchee.Application.WebResponse;

namespace Vouchee.Controllers
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
		[HttpGet("CategoryStatistics")]
		public ResponseResult<ICollection<CategoryReponse>> CategoryStatistics()
		{
			return _service.CategoryStatistics();
		}
		[HttpGet("GetCategory/{id}")]
		public ResponseResult<CategoryReponse> GetCategory(int id)
		{
			return _service.GetCategory(id);
		}

		[HttpGet("GetListCategory")]
		public DynamicModelResponse.DynamicModelsResponse<CategoryReponse> GetListCategory([FromQuery] CategoryFilter filter, [FromQuery] PagingRequest paging)
		{
			return _service.GetCategorys(filter, paging);
		}

		[HttpPost("CreateCategory")]
		//[Authorize(Policy = "RequireAdminRole")]
		public ResponseResult<CategoryReponse> CreateCategory([FromBody] CreateCategoryRequest request)
		{
			return _service.CreateCategory(request);
		}

		[HttpPut("UpdateCategory/{id}")]
		//[Authorize(Policy = "RequireAdminRole")]
		public ResponseResult<CategoryReponse> UpdateCategory([FromBody] UpdateCategoryRequest request, int id)
		{
			return _service.UpdateCategory(request, id);
		}

		[HttpDelete("DeleteCategory/{id}")]
		//[Authorize(Policy = "RequireAdminRole")]
		public ResponseResult<CategoryReponse> DeleteCategory(int id)
		{
			return _service.DeleteCategory(id);
		}
	}
}
