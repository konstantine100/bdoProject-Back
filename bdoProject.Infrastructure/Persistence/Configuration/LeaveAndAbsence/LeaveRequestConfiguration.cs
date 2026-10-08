using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdoProject.Infrastructure.Persistence.Configuration.LeaveAndAbsence;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.HasData(LeaveRequestSeeder.SeededLeaveRequests().WithStaticTimestamps());
    }
}