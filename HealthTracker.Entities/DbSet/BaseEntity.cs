namespace HealthTracker.Entities.DbSet;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = new Guid();
    public Status Status { get; set; } = Status.Active;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; }
}

public enum Status : byte
{
    Inactive = 0,
    Active = 1
}