using bdoProject.Domain.Common.Results;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Commands.CancelRequest;

public sealed record CancelRequestCommand(string EmployeeId, int RequestId) : IRequest<Result<string>>;