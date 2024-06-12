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
        public ResponseResult<TagResponse> GetTag(Guid id);
        public ResponseResult<TagResponse> UpdateTag(UpdateTagRequest request, Guid id);
        public ResponseResult<TagResponse> DeleteTag(int id);
        public ResponseResult<TagResponse> CreateTag(CreateTagRequest request);
        public DynamicModelsResponse<TagResponse> GetTags(TagFilter request, PagingRequest paging);
    }
}
