using bdoProject.Application.Contracts.LeaveAndAbsence;
using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Queries.AllEmployeeAvailableDays;

public sealed class AllEmployeeAvailableDaysHandler : IRequestHandler<AllEmployeeAvailableDaysQuery, IReadOnlyList<EmployeeAvailableDaysRequest>>
{
    private readonly IDataContext _context;

    public AllEmployeeAvailableDaysHandler(IDataContext context) => _context = context;

    public async Task<IReadOnlyList<EmployeeAvailableDaysRequest>> Handle(AllEmployeeAvailableDaysQuery request, CancellationToken cancellationToken)
    {
        var employeeEntitlements = await _context.LeaveEntitlements
            .ToListAsync(cancellationToken);

        if (!employeeEntitlements.Any())
            throw new ArgumentException("თანამშრომლების მონაცემები ვერ მოიძებნა!");

        var employeeRequests = await _context.LeaveRequests
            .Where(x => x.StartDate.Year == DateTime.UtcNow.Year && 
                                    (x.Status == LEAVE_REQUEST_STATUS.Approved  ||
                                     x.Status == LEAVE_REQUEST_STATUS.Pending))
            .ToListAsync(cancellationToken);
        
        List<EmployeeAvailableDaysRequest> daysAvailable = new List<EmployeeAvailableDaysRequest>();

        foreach (var entitlement in employeeEntitlements)
        {
            int availableDays = entitlement.EntitledDays + entitlement.CarriedOverDays;
            
            var singleEmployeeRequests = employeeRequests.Where(x => x.EmployeeId == entitlement.EmployeeId).ToList();
            
            if(singleEmployeeRequests.Any())
                availableDays = entitlement.EntitledDays + entitlement.CarriedOverDays -
                                employeeRequests.Where(x => x.LeaveType == entitlement.LeaveType)
                                    .Sum(x => x.Days);
            
            if(availableDays < 0)
                availableDays = 0;

            EmployeeAvailableDaysRequest availableDaysRequest = new EmployeeAvailableDaysRequest
            {
                EmployeeId = entitlement.EmployeeId,
                LeaveType = entitlement.LeaveType,
                AvailableDays = availableDays
            };
                
            daysAvailable.Add(availableDaysRequest);
        }

        IReadOnlyList<EmployeeAvailableDaysRequest> result = daysAvailable;

        return result;
    }
}