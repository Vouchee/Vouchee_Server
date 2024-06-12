using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Rating;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpGet("GetRating/{id}")]
        public async Task<ResponseResult<RatingResponse>> GetRating(Guid id)
        {
            return await _service.GetRating(id);
        }

        [HttpGet("GetListRating")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<RatingResponse>> GetListRating([FromQuery] RatingFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetRatings(filter, paging);
        }

        [HttpPost("CreateRating")]
        public async Task<ResponseResult<RatingResponse>> CreateRating([FromBody] CreateRatingRequest request)
        {
            return await _service.CreateRating(request);
        }

        [HttpPut("UpdateRating/{id}")]
        public async Task<ResponseResult<RatingResponse>> UpdateRating([FromBody] UpdateRatingRequest request, Guid id)
        {
            return await _service.UpdateRating(request, id);
        }

        [HttpDelete("DeleteRating/{id}")]
        public async Task<ResponseResult<RatingResponse>> DeleteRating(Guid id)
        {
            return await _service.DeleteRating(id);
        }
    }
}
