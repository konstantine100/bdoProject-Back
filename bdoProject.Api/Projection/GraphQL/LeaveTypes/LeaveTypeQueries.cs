using bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveType;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.LeaveTypes;

[QueryType, Authorize]
public class LeaveTypeQueries
{
    public async Task<IQueryable<LeaveType>> LeaveTypes(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllLeaveTypeQuery(), ct);
    }
}