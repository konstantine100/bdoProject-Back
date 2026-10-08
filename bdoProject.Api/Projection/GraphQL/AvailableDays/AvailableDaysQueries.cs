using System.Security.Claims;
using bdoProject.Application.Contracts.LeaveAndAbsence;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.AllEmployeeAvailableDays;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeAvailableDays;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.AvailableDays;

[QueryType]
public class AvailableDaysQueries
{
    [Authorize(Policy = "HROnly")] 
    public async Task<IReadOnlyList<EmployeeAvailableDaysRequest>> AllEmployeeAvailableDays(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllEmployeeAvailableDaysQuery(), ct);
    }
    
    [Authorize(Policy = "HROnly")] 
    public async Task<IReadOnlyList<EmployeeAvailableDaysRequest>> EmployeeAvailableDays(
        string employeeId,
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new EmployeeAvailableDaysQuery(employeeId), ct);
    }
    
    [Authorize] 
    public async Task<IReadOnlyList<EmployeeAvailableDaysRequest>> MyAvailableDays(
        [Service] IMediator mediator,
        CancellationToken ct,
        IHttpContextAccessor http)
    {
        var userIdClaim = http.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return await mediator.Send(new EmployeeAvailableDaysQuery(userIdClaim!), ct);
    }
}