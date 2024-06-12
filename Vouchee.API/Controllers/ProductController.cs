using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Product;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<ResponseResult<ProductResponse>> GetProduct(Guid id)
        {
            return await _service.GetProduct(id);
        }

        [HttpGet("GetListProduct")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<ProductResponse>> GetListProduct([FromQuery] ProductFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetProducts(filter, paging);
        }

        [HttpPost("CreateProduct")]
        public async Task<ResponseResult<ProductResponse>> CreateProduct([FromBody] CreateProductRequest request)
        {
            return await _service.CreateProduct(request);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ResponseResult<ProductResponse>> UpdateProduct([FromBody] UpdateProductRequest request, Guid id)
        {
            return await _service.UpdateProduct(request, id);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ResponseResult<ProductResponse>> DeleteProduct(Guid id)
        {
            return await _service.DeleteProduct(id);
        }
    }
}
