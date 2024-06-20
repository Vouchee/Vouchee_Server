using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vouchee.Business.RequestModels.Auth;
using Vouchee.Business.Services.Interfaces;
using Vouchee.Data.Models.Constants.Enum;
using Vouchee.Data.Models.Entities;

namespace Vouchee.API.Controllers;
[EnableCors("AllowAnyOrigins")]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;

    public AuthController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
    try
    {
        // Check model state validity
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.First());
        }

        // Check if the user with the provided email or username already exists
        var existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);
        var existingUserByUsername = await _userManager.FindByNameAsync(registerDto.Username);

        if (existingUserByEmail != null)
        {
            return StatusCode(500,$"User with email: {existingUserByEmail.Email} already exists!");
        }

        if (existingUserByUsername != null)
        {
            return StatusCode(500,$"User with username: {existingUserByUsername.UserName} already exists!");
        }

        var appUser = new User
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            Fullname = registerDto.Fullname,
            Gender = 0,
        };

        // Attempt to create the user with the provided password
        var creationResult = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (!creationResult.Succeeded)
        {
            return BadRequest(creationResult.Errors.First());
        }

        // Attempt to assign the user to the "Customer" role
        var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, SystemRole.Customer.ToString());
        if (!roleAssignmentResult.Succeeded)
        {
            // Rollback user creation if role assignment fails
            await _userManager.DeleteAsync(appUser);
            return StatusCode(500, roleAssignmentResult.Errors);
        }

        // Prepare the new account data
        var createdAccount = new NewAccountDto
        {
            Id = appUser.Id,
            Username = appUser.UserName,
            Email = appUser.Email,
            Fullname = appUser.Fullname,
            Token = _tokenService.CreateToken(appUser)
        };

        // Set the token in cookies
        // SetCookiesToken(createdAccount.Token);

        // Return success response with the token
        return Ok($"User created: {createdAccount.Token}");
    }
    catch (Exception ex)
    {
        // Return a 500 status code with a generic error message
        return StatusCode(500, "An error occurred while processing your request:" + ex);
    }
}
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Email == loginDto.Account!.ToLower() || u.UserName == loginDto.Account.ToLower());
        var roles = await _userManager.GetRolesAsync(user);

        if (user == null)
            return StatusCode(400, "User with account: " + loginDto.Account + " is not found!");
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false );
        if (!result.Succeeded)
            return Unauthorized("Wrong password !");

        var loginAcc = new NewAccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Fullname = user.Fullname,
            Email = user.Email,
            Roles = roles,
            Token = _tokenService.CreateToken(user)
        };
        return Ok(loginAcc);
    }
}