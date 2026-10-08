using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveEntitlement;

public sealed class AllLeaveEntitlementHandler : IRequestHandler<AllLeaveEntitlementQuery, IQueryable<LeaveEntitlement>>
{
    private readonly IDataContext _context;

    public AllLeaveEntitlementHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveEntitlement>> Handle(AllLeaveEntitlementQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveEntitlement> query = _context.LeaveEntitlements
            .AsNoTracking();
        
        return Task.FromResult(query);
    }
}