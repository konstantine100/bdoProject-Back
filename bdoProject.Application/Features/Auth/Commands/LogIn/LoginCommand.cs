using bdoProject.Application.Contracts.Auth;
using bdoProject.Domain.Common.Results;
using MediatR;

namespace bdoProject.Application.Features.Auth.Commands.LogIn;

public sealed record LoginCommand
(
    string Email,
    string EmployeeId
) : IRequest<Result<TokenResponse>>;