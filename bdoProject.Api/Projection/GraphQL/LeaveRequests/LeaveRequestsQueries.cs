using System.Security.Claims;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveRequest;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveRequest;
using bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveRequestFinder;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.LeaveRequests;

[QueryType]
public class LeaveRequestsQueries
{
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveRequest>> AllEmployeeLeaveRequests(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllLeaveRequestQuery(), ct);
    }
    
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveRequest>> EmployeeLeaveRequests(
        string employeeId,
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new EmployeeLeaveRequestQuery(employeeId), ct);
    }
    
    [Authorize(Policy = "HROnly")] 
    public async Task<IQueryable<LeaveRequest>> EmployeeLeaveRequestsFinder(
        List<LEAVE_TYPE>? leaveTypes,
        DateOnly? startDate,
        DateOnly? endDate,
        int? minDays,
        int? maxDays,
        List<LEAVE_REQUEST_STATUS>? leaveRequestStatuses,
        List<CREATED_VIA>? createdVia,
        SORTING? sorting,
        string? employeeId,
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new LeaveRequestFinderQuery(leaveTypes,
            startDate,
            endDate,
            minDays,
            maxDays,
            leaveRequestStatuses,
            createdVia,
            sorting,
            employeeId), ct);
    }
    
    [Authorize] 
    public async Task<IQueryable<LeaveRequest>> MyLeaveRequests(
        [Service] IMediator mediator,
        CancellationToken ct,
        IHttpContextAccessor http)
    {
        var userIdClaim = http.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return await mediator.Send(new EmployeeLeaveRequestQuery(userIdClaim!), ct);
    }
}