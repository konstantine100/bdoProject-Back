using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveRequest;

public sealed record AllLeaveRequestQuery() : IRequest<IQueryable<LeaveRequest>>;