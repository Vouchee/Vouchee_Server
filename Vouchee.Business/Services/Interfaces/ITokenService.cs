using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}