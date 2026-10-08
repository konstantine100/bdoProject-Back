using bdoProject.Domain.Enums;

namespace bdoProject.Application.Contracts.LeaveAndAbsence;

public sealed record AssistantLeaveRequest
(
    LEAVE_TYPE LeaveType,
    DateOnly StartDate,
    DateOnly EndDate,
    string? Comment
);