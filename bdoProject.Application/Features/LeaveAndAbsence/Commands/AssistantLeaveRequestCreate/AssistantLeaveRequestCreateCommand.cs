using bdoProject.Domain.Common.Results;
using bdoProject.Domain.Enums;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AssistantLeaveRequestCreate;

public sealed record AssistantLeaveRequestCreateCommand
(
    string EmployeeId,
    LEAVE_TYPE LeaveType,
    DateOnly StartDate,
    DateOnly EndDate,
    string? Comment
) : IRequest<Result<string>>;
