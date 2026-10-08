using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveEntitlement;

public sealed class EmployeeLeaveEntitlementHandler : IRequestHandler<EmployeeLeaveEntitlementQuery, IQueryable<LeaveEntitlement>>
{
    private readonly IDataContext _context;

    public EmployeeLeaveEntitlementHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveEntitlement>> Handle(EmployeeLeaveEntitlementQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveEntitlement> query = _context.LeaveEntitlements
            .Where(x => x.EmployeeId == request.EmployeeId).AsNoTracking();
        
        return Task.FromResult(query);
    }
}