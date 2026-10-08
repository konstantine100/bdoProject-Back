namespace bdoProject.Application.Contracts.LeaveAndAbsence;

public sealed record AnswerRequestRequest
(
    string EmployeeId,
    int RequestId,
    bool IsAccepted,
    string Message
);