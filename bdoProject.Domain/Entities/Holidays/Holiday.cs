using bdoProject.Domain.Common.Entities;

namespace bdoProject.Domain.Entities.Holidays;

public class Holiday : Entity
{
    public DateOnly Date { get; private set; }
    public string Name { get; private set; }

    public Holiday() { }

    public Holiday(DateOnly date, string name)
    {
        Date = date;
        Name = name;
    }
}