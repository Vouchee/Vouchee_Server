using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Promotion;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _service;

        public PromotionController(IPromotionService service)
        {
            _service = service;
        }

        [HttpGet("GetPromotion/{id}")]
        public async Task<ResponseResult<PromotionResponse>> GetPromotion(Guid id)
        {
            return await _service.GetPromotion(id);
        }

        [HttpGet("GetListPromotion")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<PromotionResponse>> GetListPromotion([FromQuery] PromotionFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetPromotions(filter, paging);
        }

        [HttpPost("CreatePromotion")]
        public async Task<ResponseResult<PromotionResponse>> CreatePromotion([FromBody] CreatePromotionRequest request)
        {
            return await _service.CreatePromotion(request);
        }

        [HttpPut("UpdatePromotion/{id}")]
        public async Task<ResponseResult<PromotionResponse>> UpdatePromotion([FromBody] UpdatePromotionRequest request, Guid id)
        {
            return await _service.UpdatePromotion(request, id);
        }

        [HttpDelete("DeletePromotion/{id}")]
        public async Task<ResponseResult<PromotionResponse>> DeletePromotion(Guid id)
        {
            return await _service.DeletePromotion(id);
        }
    }
}
