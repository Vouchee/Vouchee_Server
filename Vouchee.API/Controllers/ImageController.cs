using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Image;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;

        public ImageController(IImageService service)
        {
            _service = service;
        }

        [HttpGet("GetImage/{id}")]
        public async Task<ResponseResult<ImageResponse>> GetImage(Guid id)
        {
            return await _service.GetImage(id);
        }

        [HttpGet("GetListImage")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<ImageResponse>> GetListImage([FromQuery] ImageFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetImages(filter, paging);
        }

        [HttpPost("CreateImage")]
        public async Task<ResponseResult<ImageResponse>> CreateImage([FromBody] CreateImageRequest request)
        {
            return await _service.CreateImage(request);
        }

        [HttpPut("UpdateImage/{id}")]
        public async Task<ResponseResult<ImageResponse>> UpdateImage([FromBody] UpdateImageRequest request, Guid id)
        {
            return await _service.UpdateImage(request, id);
        }

        [HttpDelete("DeleteImage/{id}")]
        public async Task<ResponseResult<ImageResponse>> DeleteImage(Guid id)
        {
            return await _service.DeleteImage(id);
        }
    }
}
