using bdoProject.Domain.Entities.Holidays;
using bdoProject.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdoProject.Infrastructure.Persistence.Configuration.Holidays;

public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.HasData(HolidaySeeder.SeededHolidays().WithStaticTimestamps());
    }
}