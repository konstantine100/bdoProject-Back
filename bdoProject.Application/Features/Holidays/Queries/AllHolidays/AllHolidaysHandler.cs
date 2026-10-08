using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.Holidays;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.Holidays.Queries.AllHolidays;

public sealed class AllHolidaysHandler : IRequestHandler<AllHolidaysQuery, IQueryable<Holiday>>
{
    private readonly IDataContext _context;

    public AllHolidaysHandler(IDataContext context) => _context = context;

    public Task<IQueryable<Holiday>> Handle(AllHolidaysQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Holiday> query = _context.Holidays.AsNoTracking();
        
        return Task.FromResult(query);
    }
}