namespace Vouchee.Business.RequestModels.Auth;

public class LoginDto
{
    public required string Account { get; set; }
    public required string Password { get; set; }
    
}
