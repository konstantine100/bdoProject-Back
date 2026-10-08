using bdoProject.Domain.Common.Results;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.AnswerRequest;

public sealed record AnswerRequestCommand
(
    string EmployeeId,
    int RequestId,
    bool IsAccepted,
    string Message
) : IRequest<Result<string>>;