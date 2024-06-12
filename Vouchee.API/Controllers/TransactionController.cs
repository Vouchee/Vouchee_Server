using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Transaction;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet("GetTransaction/{id}")]
        public async Task<ResponseResult<TransactionResponse>> GetTransaction(Guid id)
        {
            return await _service.GetTransaction(id);
        }

        [HttpGet("GetListTransaction")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<TransactionResponse>> GetListTransaction([FromQuery] TransactionFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetTransactions(filter, paging);
        }

        [HttpPost("CreateTransaction")]
        public async Task<ResponseResult<TransactionResponse>> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            return await _service.CreateTransaction(request);
        }

        [HttpPut("UpdateTransaction/{id}")]
        public async Task<ResponseResult<TransactionResponse>> UpdateTransaction([FromBody] UpdateTransactionRequest request, Guid id)
        {
            return await _service.UpdateTransaction(request, id);
        }

        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<ResponseResult<TransactionResponse>> DeleteTransaction(Guid id)
        {
            return await _service.DeleteTransaction(id);
        }
    }
}
