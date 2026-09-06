using RaffleApp.Api.Auth.Entities;
using RaffleApp.Api.Common.Entities;
using RaffleApp.Api.Raffles.Entities;

namespace RaffleApp.Api.Participations.Entities;

public class RaffleEntry : AuditableEntity
{
    public int RaffleId { get; set; }
    public Raffle? Raffle { get; set; }
    public required string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}