using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Rating;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<ResponseResult<RatingResponse>> GetRating(Guid id);
        public Task<ResponseResult<RatingResponse>> UpdateRating(UpdateRatingRequest request, Guid id);
        public Task<ResponseResult<RatingResponse>> DeleteRating(Guid id);
        public Task<ResponseResult<RatingResponse>> CreateRating(CreateRatingRequest request);
        public Task<DynamicModelsResponse<RatingResponse>> GetRatings(RatingFilter request, PagingRequest paging);
    }
}
