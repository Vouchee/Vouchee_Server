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
        public ResponseResult<RoleResponse> GetRole(Guid id);
        public ResponseResult<RoleResponse> UpdateRole(UpdateRoleRequest request, Guid id);
        public ResponseResult<RoleResponse> DeleteRole(int id);
        public ResponseResult<RoleResponse> CreateRole(CreateRoleRequest request);
        public DynamicModelsResponse<RoleResponse> GetRoles(RoleFilter request, PagingRequest paging);
    }
}
