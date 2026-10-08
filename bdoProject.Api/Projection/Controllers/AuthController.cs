using bdoProject.Application.Contracts.Auth;
using bdoProject.Application.Features.Auth.Commands.LogIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bdoProject.Api.Projection.Controllers;

[Route("api/auth"), ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.Email, request.EmployeeId);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}