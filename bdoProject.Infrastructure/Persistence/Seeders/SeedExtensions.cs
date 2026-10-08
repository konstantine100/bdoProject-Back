using bdoProject.Domain.Common.Entities;

namespace bdoProject.Infrastructure.Persistence.Seeders;

public static class SeedExtensions
{
    private static readonly DateTime SeedCreatedAt = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static List<T> WithStaticTimestamps<T>(this IEnumerable<T> items) where T : Entity
    {
        var list = items.ToList();
        list.ForEach(e => e.CreatedAt = SeedCreatedAt);
        return list;
    }
}