using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Promotion;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IPromotionService
    {
        public ResponseResult<PromotionResponse> GetPromotion(Guid id);
        public ResponseResult<PromotionResponse> UpdatePromotion(UpdatePromotionRequest request, Guid id);
        public ResponseResult<PromotionResponse> DeletePromotion(int id);
        public ResponseResult<PromotionResponse> CreatePromotion(CreatePromotionRequest request);
        public DynamicModelsResponse<PromotionResponse> GetPromotions(PromotionFilter request, PagingRequest paging);
    }
}
