using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveRequestFinder;

public sealed class LeaveRequestFinderHandler : IRequestHandler<LeaveRequestFinderQuery, IQueryable<LeaveRequest>>
{
    private readonly IDataContext _context;

    public LeaveRequestFinderHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveRequest>> Handle(LeaveRequestFinderQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveRequest> query = _context.LeaveRequests.AsNoTracking();

        if (request.EmployeeId != null)
            query = query.Where(x => x.EmployeeId == request.EmployeeId);
        
        if (request.LeaveTypes != null)
            query = query.Where(x => request.LeaveTypes.Contains(x.LeaveType));

        if (request.StartDate.HasValue)
            query = query.Where(x => x.StartDate >= request.StartDate ||
                                     x.EndDate >= request.StartDate);
        
        if (request.EndDate.HasValue)
            query = query.Where(x => x.StartDate <= request.EndDate ||
                                     x.EndDate <= request.EndDate);

        if (request.MinDays.HasValue)
            query = query.Where(x => x.Days >= request.MinDays);
        
        if (request.MaxDays.HasValue)
            query = query.Where(x => x.Days <= request.MaxDays);

        if (request.LeaveRequestStatuses != null)
            query = query.Where(x => request.LeaveRequestStatuses.Contains(x.Status));

        if (request.CreatedVia != null)
            query = query.Where(x => request.CreatedVia.Contains(x.CreatedVia));
        
        query = request.Sorting switch
        {
            SORTING.CREATED_AT_ASC => query.OrderBy(x => x.CreatedAt),
            SORTING.CREATED_AT_DESC => query.OrderByDescending(x => x.CreatedAt),
            SORTING.START_DATE_ASC => query.OrderBy(x => x.StartDate),
            SORTING.START_DATE_DESC => query.OrderByDescending(x => x.StartDate),
            SORTING.END_DATE_ASC => query.OrderBy(x => x.EndDate),
            SORTING.END_DATE_DESC => query.OrderByDescending(x => x.EndDate),
            SORTING.DAYS_ASC => query.OrderByDescending(x => x.Days),
            SORTING.DAYS_DESC => query.OrderByDescending(x => x.Days),
            _ => query.OrderByDescending(x => x.CreatedAt)
        };
        
        return Task.FromResult(query);
    }
}