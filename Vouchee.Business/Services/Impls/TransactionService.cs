using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Transaction;
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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper, ITransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }


        public async Task<ResponseResult<TransactionResponse>> CreateTransaction(CreateTransactionRequest request)
        {
            try
            {
                var entity = _mapper.Map<Transaction>(request);

                await _transactionRepo.AddfixAsync(entity);
                await _transactionRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TransactionResponse>()
                {
                    Message = StringConstant.CREATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_transactionRepo) ;
            }
            return new ResponseResult<TransactionResponse>()
            {
                Message = StringConstant.CREATE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<TransactionResponse>> DeleteTransaction(Guid id)
        {
            try
            {
                var existedTransaction = _transactionRepo.GetByIdAsync(id).Result;

                if (existedTransaction == null)
                {
                    return new ResponseResult<TransactionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                _transactionRepo.Delete(existedTransaction);
                await _transactionRepo.SaveAsync();

            }
            catch (Exception ex)
            {
                return new ResponseResult<TransactionResponse>()
                {
                    Message = StringConstant.DELETE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_transactionRepo) ;
            }

            return new ResponseResult<TransactionResponse>()
            {
                Message = StringConstant.DELETE_INFO_SUCCESS,
                Result = true
            };
        }

        public async Task<ResponseResult<TransactionResponse>> GetTransaction(Guid id)
        {
            TransactionResponse result;

            try
            {
                result = _mapper.Map<TransactionResponse>(_transactionRepo.GetByIdAsync(id).Result);

                if (result == null)
                {
                    return new ResponseResult<TransactionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<TransactionResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_transactionRepo) ;
            }

            return new ResponseResult<TransactionResponse>()
            {
                Value = result,
            };
        }

        public async Task<DynamicModelResponse.DynamicModelsResponse<TransactionResponse>> GetTransactions(TransactionFilter request, PagingRequest paging)
        {
            (int, IQueryable<TransactionResponse>) result;
            try
            {
                var query = _transactionRepo.GetAllAsync().Result;
                var filtercheck = request.GetType().GetProperties().All(p => p.GetValue(request) != null);
                var mappedRequest = filtercheck ? _mapper.Map<TransactionResponse>(request) : null;
                var filteredQuery = mappedRequest != null
                    ? query.ProjectTo<TransactionResponse>(_mapper.ConfigurationProvider).DynamicFilter(mappedRequest)
                    : query.ProjectTo<TransactionResponse>(_mapper.ConfigurationProvider);

                result = filteredQuery.PagingIQueryable(paging.Page, paging.PageSize, StringConstant.LimitPaging, StringConstant.DefaultPaging);

                if (result.Item2.ToList().Count() == 0)
                {
                    return new DynamicModelResponse.DynamicModelsResponse<TransactionResponse>()
                    {
                        Message = StringConstant.EMPTY_INFO,
                    };
                }
            }
            catch (Exception ex)
            {
                return new DynamicModelResponse.DynamicModelsResponse<TransactionResponse>()
                {
                    Message = StringConstant.LOAD_INFO_FAILED,
                };
            }
            finally
            {
                lock (_transactionRepo) ;
            }
            return new DynamicModelResponse.DynamicModelsResponse<TransactionResponse>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = paging.Page,
                    Size = paging.PageSize
                },
                Results = result.Item2.ToList()
            };
        }

        public async Task<ResponseResult<TransactionResponse>> UpdateTransaction(UpdateTransactionRequest request, Guid id)
        {
            try
            {
                var existedTransaction = _transactionRepo.GetByIdAsync(id).Result;

                if (existedTransaction == null)
                {
                    return new ResponseResult<TransactionResponse>()
                    {
                        Message = StringConstant.NOT_FOUND_INFO,
                        Result = false
                    };
                }

                var newTransaction = _mapper.Map<Transaction>(request);

                _transactionRepo.UpdatefixAsync(newTransaction);
                await _transactionRepo.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ResponseResult<TransactionResponse>()
                {
                    Message = StringConstant.UPDATE_INFO_FAILED,
                    Result = false
                };
            }
            finally
            {
                lock (_transactionRepo) ;
            }

            return new ResponseResult<TransactionResponse>()
            {
                Message = StringConstant.UPDATE_INFO_SUCCESS,
                Result = true
            };
        }
    }
}
