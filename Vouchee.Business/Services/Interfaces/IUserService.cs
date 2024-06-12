using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vouchee.Business.ResponseModels.Helpers.DynamicModelResponse;
using Vouchee.Business.FilterModels;
using Vouchee.Business.RequestModels.User;
using Vouchee.Business.RequestModels.Helpers;
using Vouchee.Business.ResponseModels.Helpers;
using Vouchee.Business.ResponseModels;

namespace Vouchee.Business.Services.Interfaces
{
    public interface IUserService
    {
        public ResponseResult<UserResponse> GetUser(Guid id);
        public ResponseResult<UserResponse> UpdateUser(UpdateUserRequest request, Guid id);
        public ResponseResult<UserResponse> DeleteUser(int id);
        public ResponseResult<UserResponse> CreateUser(CreateUserRequest request);
        public DynamicModelsResponse<UserResponse> GetUsers(UserFilter request, PagingRequest paging);
    }
}
