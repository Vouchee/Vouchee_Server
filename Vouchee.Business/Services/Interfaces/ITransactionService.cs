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
        public ResponseResult<TransactionResponse> GetTransaction(Guid id);
        public ResponseResult<TransactionResponse> UpdateTransaction(UpdateTransactionRequest request, Guid id);
        public ResponseResult<TransactionResponse> DeleteTransaction(int id);
        public ResponseResult<TransactionResponse> CreateTransaction(CreateTransactionRequest request);
        public DynamicModelsResponse<TransactionResponse> GetTransactions(TransactionFilter request, PagingRequest paging);
    }
}
