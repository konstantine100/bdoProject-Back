using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveEntitlement;

public sealed record EmployeeLeaveEntitlementQuery(string EmployeeId) : IRequest<IQueryable<LeaveEntitlement>>;