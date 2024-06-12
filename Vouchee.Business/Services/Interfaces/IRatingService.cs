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
        public ResponseResult<RatingResponse> GetRating(Guid id);
        public ResponseResult<RatingResponse> UpdateRating(UpdateRatingRequest request, Guid id);
        public ResponseResult<RatingResponse> DeleteRating(int id);
        public ResponseResult<RatingResponse> CreateRating(CreateRatingRequest request);
        public DynamicModelsResponse<RatingResponse> GetRatings(RatingFilter request, PagingRequest paging);
    }
}
