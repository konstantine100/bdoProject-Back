using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdoProject.Infrastructure.Persistence.Configuration.LeaveAndAbsence;

public class LeaveEntitlementConfiguration : IEntityTypeConfiguration<LeaveEntitlement>
{
    public void Configure(EntityTypeBuilder<LeaveEntitlement> builder)
    {
        builder.HasData(LeaveEntitlementSeeder.SeededLeaveEntitlements().WithStaticTimestamps());
    }
}