using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdoProject.Infrastructure.Persistence.Configuration.LeaveAndAbsence;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(LeaveTypeSeeder.SeededLeaveTypes().WithStaticTimestamps());
    }
}