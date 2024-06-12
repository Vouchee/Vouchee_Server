using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Comment;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<ResponseResult<CommentResponse>> GetComment(Guid id);
        public Task<ResponseResult<CommentResponse>> UpdateComment(UpdateCommentRequest request, Guid id);
        public Task<ResponseResult<CommentResponse>> DeleteComment(Guid id);
        public Task<ResponseResult<CommentResponse>> CreateComment(CreateCommentRequest request);
        public Task<DynamicModelsResponse<CommentResponse>> GetComments(CommentFilter request, PagingRequest paging);
    }
}
