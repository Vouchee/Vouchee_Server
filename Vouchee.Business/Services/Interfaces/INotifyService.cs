using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Notify;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface INotifyService
    {
        public ResponseResult<NotifyResponse> GetNotify(Guid id);
        public ResponseResult<NotifyResponse> UpdateNotify(UpdateNotifyRequest request, Guid id);
        public ResponseResult<NotifyResponse> DeleteNotify(int id);
        public ResponseResult<NotifyResponse> CreateNotify(CreateNotifyRequest request);
        public DynamicModelsResponse<NotifyResponse> GetNotifies(NotifyFilter request, PagingRequest paging);
    }
}
