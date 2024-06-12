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
    public interface iWalletService
    {
        public ResponseResult<WalletResponse> GetWallet(Guid id);
        public ResponseResult<WalletResponse> UpdateWallet(UpdateWalletRequest request, Guid id);
        public ResponseResult<WalletResponse> DeleteWallet(int id);
        public ResponseResult<WalletResponse> CreateWallet(CreateWalletRequest request);
        public DynamicModelsResponse<WalletResponse> GetWallets(WalletFilter request, PagingRequest paging);
    }
}
