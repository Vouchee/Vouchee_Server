using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Image;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IImageService
    {
        public Task<ResponseResult<ImageResponse>> GetImage(Guid id);
        public Task<ResponseResult<ImageResponse>> UpdateImage(UpdateImageRequest request, Guid id);
        public Task<ResponseResult<ImageResponse>> DeleteImage(Guid id);
        public Task<ResponseResult<ImageResponse>> CreateImage(CreateImageRequest request);
        public Task<DynamicModelsResponse<ImageResponse>> GetImages(ImageFilter request, PagingRequest paging);
    }
}
