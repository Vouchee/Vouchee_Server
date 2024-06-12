using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Transaction;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task<ResponseResult<TransactionResponse>> GetTransaction(Guid id);
        public Task<ResponseResult<TransactionResponse>> UpdateTransaction(UpdateTransactionRequest request, Guid id);
        public Task<ResponseResult<TransactionResponse>> DeleteTransaction(Guid id);
        public Task<ResponseResult<TransactionResponse>> CreateTransaction(CreateTransactionRequest request);
        public Task<DynamicModelsResponse<TransactionResponse>> GetTransactions(TransactionFilter request, PagingRequest paging);
    }
}
