using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveEntitlement;

public sealed record AllLeaveEntitlementQuery() : IRequest<IQueryable<LeaveEntitlement>>;