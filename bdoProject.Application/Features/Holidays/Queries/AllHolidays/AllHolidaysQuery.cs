using bdoProject.Domain.Entities.Holidays;
using MediatR;

namespace bdoProject.Application.Features.Holidays.Queries.AllHolidays;

public sealed record AllHolidaysQuery() : IRequest<IQueryable<Holiday>>;