using bdoProject.Application.Features.Holidays.Queries.AllHolidays;
using bdoProject.Domain.Entities.Holidays;
using HotChocolate.Authorization;
using MediatR;

namespace bdoProject.Api.Projection.GraphQL.Holidays;

[QueryType, Authorize]
public class HolidaysQueries
{
    public async Task<IQueryable<Holiday>> Holidays(
        [Service] IMediator mediator,
        CancellationToken ct)
    {
        return await mediator.Send(new AllHolidaysQuery(), ct);
    }
}