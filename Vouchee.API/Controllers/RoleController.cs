using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.Role;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("GetRole/{id}")]
        public async Task<ResponseResult<RoleResponse>> GetRole(Guid id)
        {
            return await _service.GetRole(id);
        }

        [HttpGet("GetListRole")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<RoleResponse>> GetListRole([FromQuery] RoleFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetRoles(filter, paging);
        }

        [HttpPost("CreateRole")]
        public async Task<ResponseResult<RoleResponse>> CreateRole([FromBody] CreateRoleRequest request)
        {
            return await _service.CreateRole(request);
        }

        [HttpPut("UpdateRole/{id}")]
        public async Task<ResponseResult<RoleResponse>> UpdateRole([FromBody] UpdateRoleRequest request, Guid id)
        {
            return await _service.UpdateRole(request, id);
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<ResponseResult<RoleResponse>> DeleteRole(Guid id)
        {
            return await _service.DeleteRole(id);
        }
    }
}
