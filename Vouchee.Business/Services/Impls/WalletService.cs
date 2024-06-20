using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Wallet;
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
using Vouchee.Data.Repositories.Repos;

namespace Vouchee.Business.Services.Impls
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepo _walletRepo;
        private readonly IMapper _mapper;

        public WalletService(IMapper mapper, IWalletRepo walletRepo)
        {
            _walletRepo = walletRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<WalletResponse>> CreateWallet(CreateWalletRequest request)
        {
            try
            {
                var entity = _mapper.Map<Wallet>(request);
                await _walletRepo.AddAsync(_mapper.Map<Wallet>(request));
                await _walletRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<WalletResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_walletRepo) ;
            }
            return new ResponseResult<WalletResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<WalletResponse>> DeleteWallet(Guid id)
        {
            try
            {
                var existedWallet = _walletRepo.GetByIdAsync(id).Result;

                if (existedWallet == null)
                {
                    return new ResponseResult<WalletResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _walletRepo.Delete(existedWallet);
                await _walletRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<WalletResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_walletRepo) ;
            }

            return new ResponseResult<WalletResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<WalletResponse>> GetWallet(Guid id)
        {
            WalletResponse result;

            try
            {
                result = _mapper.Map<WalletResponse>(_walletRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<WalletResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<WalletResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_walletRepo) ;
            }

            return new ResponseResult<WalletResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<WalletResponse>> GetWallets(WalletFilter request, PagingRequest paging)
        {
            (int, IQueryable<WalletResponse>) result;
            try
            {
                var query = _walletRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<WalletResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<WalletResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<WalletResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<WalletResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<WalletResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_walletRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<WalletResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<WalletResponse>> UpdateWallet(UpdateWalletRequest request, Guid id)
        {
            try
            {
                var existedWallet = _walletRepo.GetByIdAsync(id).Result;

                if (existedWallet == null)
                {
                    return new ResponseResult<WalletResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newWallet = _mapper.Map<Wallet>(request);

                _walletRepo.Update(newWallet);
                await _walletRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<WalletResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_walletRepo) ;
            }

            return new ResponseResult<WalletResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
