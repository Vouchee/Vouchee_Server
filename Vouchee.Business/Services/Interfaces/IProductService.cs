using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Product;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ResponseResult<ProductResponse>> GetProduct(Guid id);
        public Task<ResponseResult<ProductResponse>> UpdateProduct(UpdateProductRequest request, Guid id);
        public Task<ResponseResult<ProductResponse>> DeleteProduct(Guid id);
        public Task<ResponseResult<ProductResponse>> CreateProduct(CreateProductRequest request);
        public Task<DynamicModelsResponse<ProductResponse>> GetProducts(ProductFilter request, PagingRequest paging);
    }
}
