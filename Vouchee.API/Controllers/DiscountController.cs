using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Discount;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountController(IDiscountService service)
        {
            _service = service;
        }

        [HttpGet("GetDiscount/{id}")]
        public async Task<ResponseResult<DiscountResponse>> GetDiscount(Guid id)
        {
            return await _service.GetDiscount(id);
        }

        [HttpGet("GetListDiscount")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<DiscountResponse>> GetListDiscount([FromQuery] DiscountFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetDiscounts(filter, paging);
        }

        [HttpPost("CreateDiscount")]
        public async Task<ResponseResult<DiscountResponse>> CreateDiscount([FromBody] CreateDiscountRequest request)
        {
            return await _service.CreateDiscount(request);
        }

        [HttpPut("UpdateDiscount/{id}")]
        public async Task<ResponseResult<DiscountResponse>> UpdateDiscount([FromBody] UpdateDiscountRequest request, Guid id)
        {
            return await _service.UpdateDiscount(request, id);
        }

        [HttpDelete("DeleteDiscount/{id}")]
        public async Task<ResponseResult<DiscountResponse>> DeleteDiscount(Guid id)
        {
            return await _service.DeleteDiscount(id);
        }
    }
}
