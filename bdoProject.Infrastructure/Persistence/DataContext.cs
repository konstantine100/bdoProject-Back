using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.Employees;
using bdoProject.Domain.Entities.Holidays;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Infrastructure.Persistence;

public sealed class DataContext : DbContext, IDataContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Holiday> Holidays => Set<Holiday>();
    public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
    public DbSet<LeaveEntitlement> LeaveEntitlements => Set<LeaveEntitlement>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

}