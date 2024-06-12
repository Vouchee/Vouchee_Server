using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Product;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Models.Entities;
using AutoMapper;
using Vouchee.Data.Repositories.Interfaces;
using Vouchee.Data.Models.Constants;
using AutoMapper.QueryableExtensions;
using Vouchee.Business.Helpers;

namespace Vouchee.Business.Services.Impls
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepo productRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<ProductResponse>> CreateProduct(CreateProductRequest request)
        {
            try
            {
                var entity = _mapper.Map<Product>(request);
                await _productRepo.AddAsync(_mapper.Map<Product>(request));
                await _productRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ProductResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_productRepo) ;
            }
            return new ResponseResult<ProductResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ProductResponse>> DeleteProduct(Guid id)
        {
            try
            {
                var existedProduct = _productRepo.GetByIdAsync(id).Result;

                if (existedProduct == null)
                {
                    return new ResponseResult<ProductResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _productRepo.Delete(existedProduct);
                await _productRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<ProductResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_productRepo) ;
            }

            return new ResponseResult<ProductResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<ProductResponse>> GetProduct(Guid id)
        {
            ProductResponse result;

            try
            {
                result = _mapper.Map<ProductResponse>(_productRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<ProductResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<ProductResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_productRepo) ;
            }

            return new ResponseResult<ProductResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<ProductResponse>> GetProducts(ProductFilter request, PagingRequest paging)
        {
            (int, IQueryable<ProductResponse>) result;
            try
            {
                result = _productRepo.GetAllAsync().Result
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .DynamicFilter(_mapper.Map<ProductResponse>(request))
                    .PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<ProductResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<ProductResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_productRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<ProductResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<ProductResponse>> UpdateProduct(UpdateProductRequest request, Guid id)
        {
            try
            {
                var existedProduct = _productRepo.GetByIdAsync(id).Result;

                if (existedProduct == null)
                {
                    return new ResponseResult<ProductResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newProduct = _mapper.Map<Product>(request);

                _productRepo.Update(newProduct);
                await _productRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<ProductResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_productRepo) ;
            }

            return new ResponseResult<ProductResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
