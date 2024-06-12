using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Category;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.RequestModels.Comment;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ICommentService
    {
        public ResponseResult<CommentResponse> GetComment(Guid id);
        public ResponseResult<CommentResponse> UpdateComment(UpdateCommentRequest request, Guid id);
        public ResponseResult<CommentResponse> DeleteComment(int id);
        public ResponseResult<CommentResponse> CreateComment(CreateCommentRequest request);
        public DynamicModelsResponse<CommentResponse> GetComments(CommentFilter request, PagingRequest paging);
    }
}
