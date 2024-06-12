using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Shop;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;

        public ShopController(IShopService service)
        {
            _service = service;
        }

        [HttpGet("GetShop/{id}")]
        public async Task<ResponseResult<ShopResponse>> GetShop(Guid id)
        {
            return await _service.GetShop(id);
        }

        [HttpGet("GetListShop")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<ShopResponse>> GetListShop([FromQuery] ShopFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetShops(filter, paging);
        }

        [HttpPost("CreateShop")]
        public async Task<ResponseResult<ShopResponse>> CreateShop([FromBody] CreateShopRequest request)
        {
            return await _service.CreateShop(request);
        }

        [HttpPut("UpdateShop/{id}")]
        public async Task<ResponseResult<ShopResponse>> UpdateShop([FromBody] UpdateShopRequest request, Guid id)
        {
            return await _service.UpdateShop(request, id);
        }

        [HttpDelete("DeleteShop/{id}")]
        public async Task<ResponseResult<ShopResponse>> DeleteShop(Guid id)
        {
            return await _service.DeleteShop(id);
        }
    }
}
