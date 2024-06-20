using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.User;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;
using Vouchee.Business.Services.Interfaces;

namespace Vouchee.API.Controllers
{
    [EnableCors("AllowAnyOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ResponseResult<UserResponse>> GetUser(Guid id)
        {
            return await _service.GetUser(id);
        }

        [HttpGet("GetListUser")]
        public async Task<DynamicModelResponse.DynamicModelsResponse<UserResponse>> GetListUser([FromQuery] UserFilter filter, [FromQuery] PagingRequest paging)
        {
            return await _service.GetUsers(filter, paging);
        }

        [HttpPost("CreateUser")]
        public async Task<ResponseResult<UserResponse>> CreateUser([FromBody] CreateUserRequest request)
        {
            return await _service.CreateUser(request);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ResponseResult<UserResponse>> UpdateUser([FromBody] UpdateUserRequest request, Guid id)
        {
            return await _service.UpdateUser(request, id);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ResponseResult<UserResponse>> DeleteUser(Guid id)
        {
            return await _service.DeleteUser(id);
        }
    }
}