using Application.Features.Contracts;
using Application.Responses;
using Core.Wrappers;

namespace Application.Interfaces;
public interface ILoginCommandHandler
{
    Task<Result<LoginResponse>> Login(LoginCommand command, CancellationToken cancellationToken);
    Task<Result<UserResponse>> Register(RegisterCommand request, CancellationToken cancellationToken);
}
