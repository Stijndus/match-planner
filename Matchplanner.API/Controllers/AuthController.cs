using Matchplanner.Shared.DTO;
using Matchplanner.Shared.Models;
using Matchplanner.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matchplanner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]

    public class AuthController(IAuthService authService): ControllerBase
    {

    [HttpPost("login")]
    public async Task<UserModel?> Login([FromBody] LoginRequestDTO dto)
    {
        return await authService.Login(dto.Email, dto.Password);
    }

    [HttpPost("register")]
    public async Task Register([FromBody] UserModel user)
    {
        await authService.Register(user);
    }
}

