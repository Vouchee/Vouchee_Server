using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Location;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet("GetLocation/{id}")]
        public async Task<ResponseResult<LocationResponse>> GetLocation(Guid id)
        {
            return await _service.GetLocation(id);
        }

        [HttpGet("GetListLocation")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<LocationResponse>> GetListLocation([FromQuery] LocationFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetLocations(filter, paging);
        }

        [HttpPost("CreateLocation")]
        public async Task<ResponseResult<LocationResponse>> CreateLocation([FromBody] CreateLocationRequest request)
        {
            return await _service.CreateLocation(request);
        }

        [HttpPut("UpdateLocation/{id}")]
        public async Task<ResponseResult<LocationResponse>> UpdateLocation([FromBody] UpdateLocationRequest request, Guid id)
        {
            return await _service.UpdateLocation(request, id);
        }

        [HttpDelete("DeleteLocation/{id}")]
        public async Task<ResponseResult<LocationResponse>> DeleteLocation(Guid id)
        {
            return await _service.DeleteLocation(id);
        }
    }
}
