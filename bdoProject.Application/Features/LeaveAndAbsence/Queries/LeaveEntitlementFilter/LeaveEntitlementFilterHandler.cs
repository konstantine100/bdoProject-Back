using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.LeaveEntitlementFilter;

public sealed class LeaveEntitlementFilterHandler : IRequestHandler<LeaveEntitlementFilterQuery, IQueryable<LeaveEntitlement>>
{
    private readonly IDataContext _context;

    public LeaveEntitlementFilterHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveEntitlement>> Handle(LeaveEntitlementFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveEntitlement> query = _context.LeaveEntitlements
            .AsNoTracking();

        if (request.LeaveType.HasValue)
            query = query.Where(x => x.LeaveType == request.LeaveType);

        if (request.EmployeeId != null)
            query = query.Where(x => x.EmployeeId == request.EmployeeId);
        
        return Task.FromResult(query);
    }
}