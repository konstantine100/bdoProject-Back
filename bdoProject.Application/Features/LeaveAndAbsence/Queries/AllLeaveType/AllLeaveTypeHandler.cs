using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllLeaveType;

public sealed class AllLeaveTypeHandler : IRequestHandler<AllLeaveTypeQuery, IQueryable<LeaveType>>
{
    private readonly IDataContext _context;

    public AllLeaveTypeHandler(IDataContext context) => _context = context;

    public Task<IQueryable<LeaveType>> Handle(AllLeaveTypeQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LeaveType> query = _context.LeaveTypes
            .AsNoTracking();
        
        return Task.FromResult(query);
    }
}