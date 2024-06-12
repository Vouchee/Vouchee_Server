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
        public ResponseResult<ShopResponse> GetShop(Guid id);
        public ResponseResult<ShopResponse> UpdateShop(UpdateShopRequest request, Guid id);
        public ResponseResult<ShopResponse> DeleteShop(int id);
        public ResponseResult<ShopResponse> CreateShop(CreateShopRequest request);
        public DynamicModelsResponse<ShopResponse> GetShops(ShopFilter request, PagingRequest paging);
    }
}
