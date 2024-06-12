using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Wallet;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _service;

        public WalletController(IWalletService service)
        {
            _service = service;
        }

        [HttpGet("GetWallet/{id}")]
        public async Task<ResponseResult<WalletResponse>> GetWallet(Guid id)
        {
            return await _service.GetWallet(id);
        }

        [HttpGet("GetListWallet")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<WalletResponse>> GetListWallet([FromQuery] WalletFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetWallets(filter, paging);
        }

        [HttpPost("CreateWallet")]
        public async Task<ResponseResult<WalletResponse>> CreateWallet([FromBody] CreateWalletRequest request)
        {
            return await _service.CreateWallet(request);
        }

        [HttpPut("UpdateWallet/{id}")]
        public async Task<ResponseResult<WalletResponse>> UpdateWallet([FromBody] UpdateWalletRequest request, Guid id)
        {
            return await _service.UpdateWallet(request, id);
        }

        [HttpDelete("DeleteWallet/{id}")]
        public async Task<ResponseResult<WalletResponse>> DeleteWallet(Guid id)
        {
            return await _service.DeleteWallet(id);
        }
    }
}
