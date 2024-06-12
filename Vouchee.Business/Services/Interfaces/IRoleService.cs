using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Role;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<ResponseResult<RoleResponse>> GetRole(Guid id);
        public Task<ResponseResult<RoleResponse>> UpdateRole(UpdateRoleRequest request, Guid id);
        public Task<ResponseResult<RoleResponse>> DeleteRole(Guid id);
        public Task<ResponseResult<RoleResponse>> CreateRole(CreateRoleRequest request);
        public Task<DynamicModelsResponse<RoleResponse>> GetRoles(RoleFilter request, PagingRequest paging);
    }
}
