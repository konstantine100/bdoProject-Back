using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveEntitlementFilter;

public sealed record LeaveEntitlementFilterQuery
(
    LEAVE_TYPE? LeaveType,
    string? EmployeeId
) : IRequest<IQueryable<LeaveEntitlement>>;