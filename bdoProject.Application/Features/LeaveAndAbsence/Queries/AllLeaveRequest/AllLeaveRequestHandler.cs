using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveRequest;

public sealed class AllLeaveRequestHandler : IRequestHandler<AllLeaveRequestQuery, IQueryable<LeaveRequest>>
{
    private readonly IDataContext _context;

    public AllLeaveRequestHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveRequest>> Handle(AllLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveRequest> query = _context.LeaveRequests
            .OrderByDescending(x => x.CreatedAt).AsNoTracking();
        
        return Task.FromResult(query);
    }
}