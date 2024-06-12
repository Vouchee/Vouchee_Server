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
        public ResponseResult<LocationResponse> GetLocation(Guid id);
        public ResponseResult<LocationResponse> UpdateLocation(UpdateLocationRequest request, Guid id);
        public ResponseResult<LocationResponse> DeleteLocation(int id);
        public ResponseResult<LocationResponse> CreateLocation(CreateLocationRequest request);
        public DynamicModelsResponse<LocationResponse> GetLocations(LocationFilter request, PagingRequest paging);
    }
}
