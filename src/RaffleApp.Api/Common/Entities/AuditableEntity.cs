namespace RaffleApp.Api.Common.Entities;

public abstract class AuditableEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedByUserId { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedByUserId { get; set; }
    public required bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedByUserId { get; set; }
}