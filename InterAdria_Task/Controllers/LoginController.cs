using Application.DTOs;
using Application.Features.Contracts;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterAdria_Task.Controllers;
[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginCommandHandler _login;

    public LoginController(ILoginCommandHandler login)
    {
        _login = login;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        var toCommand = new LoginCommand
        {
            Password = request.Password,
            Username = request.Username
        };

        var result = await _login.Login(toCommand, cancellationToken).ConfigureAwait(false);

        if (result.HasError)
        {
            return Unauthorized();
        }

        return Ok(result.Data);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
    {
        var toCommand = new RegisterCommand
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            UserName = request.UserName
        };

        var result = await _login.Register(toCommand, cancellationToken).ConfigureAwait(false);

        if (result.HasError)
        {
            return NotFound();
        }

        return Ok(result.Data);
    }
}
