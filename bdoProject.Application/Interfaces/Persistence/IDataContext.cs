using bdoProject.Domain.Entities.Employees;
using bdoProject.Domain.Entities.Holidays;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Interfaces.Persistence;

public interface IDataContext
{
    // Employees
    DbSet<Employee>  Employees { get; }
    
    // Holidays
    DbSet<Holiday>  Holidays { get; }
    
    // Leave
    DbSet<LeaveType>  LeaveTypes { get; }
    DbSet<LeaveEntitlement>  LeaveEntitlements { get; }
    DbSet<LeaveRequest>  LeaveRequests { get; }
    
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}