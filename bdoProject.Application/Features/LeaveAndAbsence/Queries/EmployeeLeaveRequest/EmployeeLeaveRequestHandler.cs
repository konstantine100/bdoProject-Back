using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeLeaveRequest;

public sealed class EmployeeLeaveRequestHandler : IRequestHandler<EmployeeLeaveRequestQuery, IQueryable<LeaveRequest>>
{
    private readonly IDataContext _context;

    public EmployeeLeaveRequestHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveRequest>> Handle(EmployeeLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveRequest> query = _context.LeaveRequests
            .Where(x => x.EmployeeId == request.EmployeeId)
            .OrderByDescending(x => x.CreatedAt).AsNoTracking();
        
        return Task.FromResult(query);
    }
}