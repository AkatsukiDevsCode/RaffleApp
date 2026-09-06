using RaffleApp.Api.Auth.Entities;
using RaffleApp.Api.Common.Entities;

namespace RaffleApp.Api.Raffles.Entities;

public class Raffle : AuditableEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public string? WinnerId { get; set; }
    public ApplicationUser? Winner { get; set; }
    public required bool IsActive { get; set; }
    public bool IsOpenForParticipation(DateTimeOffset now) =>
        IsActive && now >= StartDate && now <= EndDate;
}