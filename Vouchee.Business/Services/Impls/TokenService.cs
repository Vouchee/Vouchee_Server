using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Models.Entities;

namespace Vouchee.Business.Services.Impls;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<User> _userManager;
    
    public TokenService(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!));
    }
    
    public string CreateToken(User user)
    {
        var roles = _userManager.GetRolesAsync(user).Result;
        
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        };
        
        claims.AddRange(roles.Select(c => new Claim(ClaimTypes.Role, c)));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(30),
            SigningCredentials = creds,
        };

        var tokenHandle = new JwtSecurityTokenHandler();

        var token = tokenHandle.CreateToken(tokenDescriptor);

        return tokenHandle.WriteToken(token);
    }
    
}