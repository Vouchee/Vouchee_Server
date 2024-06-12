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
using Vouchee.Business.RequestModels.Discount;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IDiscountService
    {
        public Task<ResponseResult<DiscountResponse>> GetDiscount(Guid id);
        public Task<ResponseResult<DiscountResponse>> UpdateDiscount(UpdateDiscountRequest request, Guid id);
        public Task<ResponseResult<DiscountResponse>> DeleteDiscount(Guid id);
        public Task<ResponseResult<DiscountResponse>> CreateDiscount(CreateDiscountRequest request);
        public Task<DynamicModelsResponse<DiscountResponse>> GetDiscounts(DiscountFilter request, PagingRequest paging);
    }
}
