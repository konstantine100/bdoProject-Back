using bdoProject.Domain.Entities.Employees;
using bdoProject.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdoProject.Infrastructure.Persistence.Configuration.Employees;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(EmployeeSeeder.SeededEmployees().WithStaticTimestamps());
    }
}