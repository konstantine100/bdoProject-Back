using System.Security.Claims;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveEntitlement;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveEntitlement;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveEntitlementFilter;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.LeaveEntitlements;

[QueryType]
public class LeaveEntitlementQueries
{
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveEntitlement>> AllLeaveEntitlements(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllLeaveEntitlementQuery(), ct);
    }
    
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveEntitlement>> EmployeeLeaveEntitlements(
        string employeeId,
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new EmployeeLeaveEntitlementQuery(employeeId), ct);
    }
    
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveEntitlement>> LeaveEntitlementsFilter(
        LEAVE_TYPE? type,
        string? employeeId,
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new LeaveEntitlementFilterQuery(type, employeeId), ct);
    }
    
    [Authorize] 
    public async Task<IQueryable<LeaveEntitlement>> MyLeaveEntitlements(
        [Service] IMediator mediator,
        CancellationToken ct,
        IHttpContextAccessor http)
    {
        var userIdClaim = http.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return await mediator.Send(new EmployeeLeaveEntitlementQuery(userIdClaim!), ct);
    }
}