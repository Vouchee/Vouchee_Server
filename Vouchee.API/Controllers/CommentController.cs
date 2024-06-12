using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Comment;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet("GetComment/{id}")]
        public async Task<ResponseResult<CommentResponse>> GetComment(Guid id)
        {
            return await _service.GetComment(id);
        }

        [HttpGet("GetListComment")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<CommentResponse>> GetListComment([FromQuery] CommentFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetComments(filter, paging);
        }

        [HttpPost("CreateComment")]
        public async Task<ResponseResult<CommentResponse>> CreateComment([FromBody] CreateCommentRequest request)
        {
            return await _service.CreateComment(request);
        }

        [HttpPut("UpdateComment/{id}")]
        public async Task<ResponseResult<CommentResponse>> UpdateComment([FromBody] UpdateCommentRequest request, Guid id)
        {
            return await _service.UpdateComment(request, id);
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<ResponseResult<CommentResponse>> DeleteComment(Guid id)
        {
            return await _service.DeleteComment(id);
        }
    }
}
