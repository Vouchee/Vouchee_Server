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
        public ResponseResult<ProductResponse> GetProduct(Guid id);
        public ResponseResult<ProductResponse> UpdateProduct(UpdateProductRequest request, Guid id);
        public ResponseResult<ProductResponse> DeleteProduct(int id);
        public ResponseResult<ProductResponse> CreateProduct(CreateProductRequest request);
        public DynamicModelsResponse<ProductResponse> GetProducts(ProductFilter request, PagingRequest paging);
    }
}
