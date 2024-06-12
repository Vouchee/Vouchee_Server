using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Tag;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ITagService
    {
        public Task<ResponseResult<TagResponse>> GetTag(Guid id);
        public Task<ResponseResult<TagResponse>> UpdateTag(UpdateTagRequest request, Guid id);
        public Task<ResponseResult<TagResponse>> DeleteTag(Guid id);
        public Task<ResponseResult<TagResponse>> CreateTag(CreateTagRequest request);
        public Task<DynamicModelsResponse<TagResponse>> GetTags(TagFilter request, PagingRequest paging);
    }
}
