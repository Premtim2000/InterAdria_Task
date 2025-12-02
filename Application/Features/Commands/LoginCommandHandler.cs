using Application.Features.Contracts;
using Application.Interfaces;
using Application.Responses;
using Application.Utils;
using Core.Entities;
using Core.Repository;
using Core.Wrappers;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Commands;
public class LoginCommandHandler : ILoginCommandHandler
{
    private readonly IJwtUtils _jwtUtils;
    private readonly ILoginRepository _loginRepository;
    private readonly IConfiguration _config;
    public LoginCommandHandler(IJwtUtils jwtUtils, ILoginRepository loginRepository, IConfiguration config)
    {
        _jwtUtils = jwtUtils;
        _loginRepository = loginRepository;
        _config = config;
    }
    public async Task<Result<LoginResponse>> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _loginRepository.GetByUsername(request.Username).ConfigureAwait(false);

        if (user == null)
        {
            return Result<LoginResponse>.Fail(new Error("User.Login", "Username or password doesn't exist"));
        }

        bool verifyPassword = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);

        if (!verifyPassword)
        {
            return Result<LoginResponse>.Fail(new Error("User.Login", "Username or password doesn't exist"));
        }

        var token = _jwtUtils.GenerateToken(user.Id.ToString());

        return Result<LoginResponse>.Successful(new LoginResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:ExpiryMinutes"]))
        });
    }

    public async Task<Result<UserResponse>> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userExists = (await _loginRepository.GetAsync(user =>
             string.Equals(user.Email, request.Email) ||
             string.Equals(user.Username, request.UserName))
         .ConfigureAwait(false)
     ).Any();

        if (userExists)
        {
            return Result<UserResponse>.Fail(new Error("User.Add", "User with this email or username already exists!"));
        }

        var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 13);

        var userResult = await _loginRepository.Add(new User
        {
            CreatedAt = DateTime.UtcNow,
            Email = request.Email,
            Id = Guid.NewGuid(),
            LastUpdatedAt = DateTime.UtcNow,
            Password = hashedPassword,
            Username = request.UserName
        });

        if (userResult is null)
        {
            return Result<UserResponse>.Fail(new Error("Customer.Add", "Failed to add customer"));
        }

        return Result<UserResponse>.Successful(new UserResponse
        {
            Email = request.Email,
            Username = request.UserName
        });
    }
}
