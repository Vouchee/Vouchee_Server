using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Tag;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }

        [HttpGet("GetTag/{id}")]
        public async Task<ResponseResult<TagResponse>> GetTag(Guid id)
        {
            return await _service.GetTag(id);
        }

        [HttpGet("GetListTag")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<TagResponse>> GetListTag([FromQuery] TagFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetTags(filter, paging);
        }

        [HttpPost("CreateTag")]
        public async Task<ResponseResult<TagResponse>> CreateTag([FromBody] CreateTagRequest request)
        {
            return await _service.CreateTag(request);
        }

        [HttpPut("UpdateTag/{id}")]
        public async Task<ResponseResult<TagResponse>> UpdateTag([FromBody] UpdateTagRequest request, Guid id)
        {
            return await _service.UpdateTag(request, id);
        }

        [HttpDelete("DeleteTag/{id}")]
        public async Task<ResponseResult<TagResponse>> DeleteTag(Guid id)
        {
            return await _service.DeleteTag(id);
        }
    }
}
