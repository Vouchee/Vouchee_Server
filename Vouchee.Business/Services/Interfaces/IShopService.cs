using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Shop;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IShopService
    {
        public Task<ResponseResult<ShopResponse>> GetShop(Guid id);
        public Task<ResponseResult<ShopResponse>> UpdateShop(UpdateShopRequest request, Guid id);
        public Task<ResponseResult<ShopResponse>> DeleteShop(Guid id);
        public Task<ResponseResult<ShopResponse>> CreateShop(CreateShopRequest request);
        public Task<DynamicModelsResponse<ShopResponse>> GetShops(ShopFilter request, PagingRequest paging);
    }
}
