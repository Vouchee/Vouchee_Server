using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Location;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<ResponseResult<LocationResponse>> GetLocation(Guid id);
        public Task<ResponseResult<LocationResponse>> UpdateLocation(UpdateLocationRequest request, Guid id);
        public Task<ResponseResult<LocationResponse>> DeleteLocation(Guid id);
        public Task<ResponseResult<LocationResponse>> CreateLocation(CreateLocationRequest request);
        public Task<DynamicModelsResponse<LocationResponse>> GetLocations(LocationFilter request, PagingRequest paging);
    }
}
