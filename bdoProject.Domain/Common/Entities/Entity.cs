namespace bdoProject.Domain.Common.Entities;

public class Entity
{
    public int Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    public void Update() => UpdatedAt = DateTime.UtcNow;
}