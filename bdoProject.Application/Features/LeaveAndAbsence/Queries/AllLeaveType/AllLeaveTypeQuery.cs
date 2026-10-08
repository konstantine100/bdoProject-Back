using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveType;

public sealed record AllLeaveTypeQuery() : IRequest<IQueryable<LeaveType>>;