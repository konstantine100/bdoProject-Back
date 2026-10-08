using bdoProject.Application.Contracts.Auth;
using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Application.Interfaces.Security;
using bdoProject.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.Auth.Commands.LogIn;

public sealed class LoginHandler : IRequestHandler<LoginCommand, Result<TokenResponse>>
{
    private readonly IDataContext _context;
    private readonly IJwtService _jwtService;

    public LoginHandler(IDataContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }
    
    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Employees
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (user == null)
            return Result<TokenResponse>.Failure(ErrorResults.InvalidCredentials());
        
        if (user.EmployeeId != request.EmployeeId)
                return Result<TokenResponse>.Failure(ErrorResults.InvalidCredentials());

        string accessToken = _jwtService.GenerateAccessToken(user);
        string refreshToken = _jwtService.GenerateAccessToken(user);
        
        return Result<TokenResponse>.Success(new TokenResponse(accessToken, refreshToken));
    }
}