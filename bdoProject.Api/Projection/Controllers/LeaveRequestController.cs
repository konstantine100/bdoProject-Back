using bdoProject.Api.Extensions.Auth;
using bdoProject.Application.Contracts.LeaveAndAbsence;
using bdoProject.Application.Features.LeaveAndAbsence.Commands.AnswerRequest;
using bdoProject.Application.Features.LeaveAndAbsence.Commands.AssistantLeaveRequestCreate;
using bdoProject.Application.Features.LeaveAndAbsence.Commands.CancelRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bdoProject.Api.Projection.Controllers;

[Route("api/leave-request"), ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly  IMediator _mediator;
    public LeaveRequestController(IMediator mediator) => _mediator = mediator;
    
    [Authorize]
    [HttpPost("hr-assistant-create-leave-request")]
    public async Task<IActionResult> Login(AssistantLeaveRequest request, CancellationToken cancellationToken)
    {

        string userId = this.GetUserId();
        
        var command = new AssistantLeaveRequestCreateCommand(userId,
            request.LeaveType,
            request.StartDate,
            request.EndDate,
            request.Comment);
        
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [Authorize]
    [HttpPut("cancel-request/{requestId}")]
    public async Task<IActionResult> CancelRequest(int requestId, CancellationToken cancellationToken)
    {
        string userId = this.GetUserId();
        
        var command = new CancelRequestCommand(userId,
            requestId);
        
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [Authorize("HROnly")]
    [HttpPut("answer-request")]
    public async Task<IActionResult> CancelRequest(AnswerRequestRequest request, CancellationToken cancellationToken)
    {
        var command = new AnswerRequestCommand(request.EmployeeId,
            request.RequestId,
            request.IsAccepted,
            request.Message);
        
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}