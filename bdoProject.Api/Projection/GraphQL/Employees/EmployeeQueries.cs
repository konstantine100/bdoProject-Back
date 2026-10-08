using System.Security.Claims;
using bdoProject.Application.Features.Employees.Queries.AllEmployees;
using bdoProject.Application.Features.Employees.Queries.GetEmployee;
using bdoProject.Domain.Entities.Employees;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.Employees;

[QueryType]
public class EmployeeQueries
{
    [Authorize(Policy = "HROnly")]
    public async Task<IQueryable<Employee>> AllEmployees(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllEmployeesQuery(), ct);
    }
    
    [Authorize]
    public async Task<IQueryable<Employee>> Me(
        [Service] IMediator mediator,
        CancellationToken ct,
        IHttpContextAccessor http)
    {
        var userIdClaim = http.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
            throw new GraphQLException("User not found!");
        
        return await mediator.Send(new GetEmployeeQuery(userIdClaim), ct);
    }
}