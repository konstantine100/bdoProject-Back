using bdoProject.Application.Contracts.LeaveAndAbsence;
using bdoProject.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.EmployeeAvailableDays;

public sealed class EmployeeAvailableDaysHandler : IRequestHandler<EmployeeAvailableDaysQuery, IReadOnlyList<EmployeeAvailableDaysRequest>>
{
    private readonly IDataContext _context;

    public EmployeeAvailableDaysHandler(IDataContext context) => _context = context;

    public async Task<IReadOnlyList<EmployeeAvailableDaysRequest>> Handle(EmployeeAvailableDaysQuery request, CancellationToken cancellationToken)
    {
         var employeeEntitlements = await _context.LeaveEntitlements
            .Where(x => x.EmployeeId == request.EmployeeId)
            .ToListAsync(cancellationToken);

        if (!employeeEntitlements.Any())
            throw new ArgumentException("თანამშრომლის მონაცემები ვერ მოიძებნა!");

        var employeeRequests = await _context.LeaveRequests
            .Where(x => x.EmployeeId == request.EmployeeId && x.StartDate.Year == DateTime.UtcNow.Year)
            .ToListAsync(cancellationToken);
        
        List<EmployeeAvailableDaysRequest> daysAvailable = new List<EmployeeAvailableDaysRequest>();

        foreach (var entitlement in employeeEntitlements)
        {
            int availableDays = entitlement.EntitledDays + entitlement.CarriedOverDays;
            
            if(employeeRequests.Any())
                availableDays = entitlement.EntitledDays + entitlement.CarriedOverDays -
                                employeeRequests.Where(x => x.LeaveType == entitlement.LeaveType)
                                    .Sum(x => x.Days);
            
            if(availableDays < 0)
                availableDays = 0;

            EmployeeAvailableDaysRequest availableDaysRequest = new EmployeeAvailableDaysRequest
            {
                EmployeeId = request.EmployeeId,
                LeaveType = entitlement.LeaveType,
                AvailableDays = availableDays
            };
                
            daysAvailable.Add(availableDaysRequest);
        }

        IReadOnlyList<EmployeeAvailableDaysRequest> result = daysAvailable;

        return result;
    }
}