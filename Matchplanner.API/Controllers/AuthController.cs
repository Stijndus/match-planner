using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]

    public class AuthController(IAuthService authService): ControllerBase
    {

    [HttpPost("login")]
    public async Task<UserModel?> Login(string email, string password)
    {
        return await authService.Login(email, password);
    }

    [HttpPost("register")]
    public async Task Register([FromBody] UserModel user)
    {
        await authService.Register(user);
    }
}

