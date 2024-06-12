using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Notify;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotifyService _service;

        public NotifyController(INotifyService service)
        {
            _service = service;
        }

        [HttpGet("GetNotify/{id}")]
        public async Task<ResponseResult<NotifyResponse>> GetNotify(Guid id)
        {
            return await _service.GetNotify(id);
        }

        [HttpGet("GetListNotify")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<NotifyResponse>> GetListNotify([FromQuery] NotifyFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetNotifies(filter, paging);
        }

        [HttpPost("CreateNotify")]
        public async Task<ResponseResult<NotifyResponse>> CreateNotify([FromBody] CreateNotifyRequest request)
        {
            return await _service.CreateNotify(request);
        }

        [HttpPut("UpdateNotify/{id}")]
        public async Task<ResponseResult<NotifyResponse>> UpdateNotify([FromBody] UpdateNotifyRequest request, Guid id)
        {
            return await _service.UpdateNotify(request, id);
        }

        [HttpDelete("DeleteNotify/{id}")]
        public async Task<ResponseResult<NotifyResponse>> DeleteNotify(Guid id)
        {
            return await _service.DeleteNotify(id);
        }
    }
}
