using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Wallet;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IWalletService
    {
        public Task<ResponseResult<WalletResponse>> GetWallet(Guid id);
        public Task<ResponseResult<WalletResponse>> UpdateWallet(UpdateWalletRequest request, Guid id);
        public Task<ResponseResult<WalletResponse>> DeleteWallet(Guid id);
        public Task<ResponseResult<WalletResponse>> CreateWallet(CreateWalletRequest request);
        public Task<DynamicModelsResponse<WalletResponse>> GetWallets(WalletFilter request, PagingRequest paging);
    }
}
