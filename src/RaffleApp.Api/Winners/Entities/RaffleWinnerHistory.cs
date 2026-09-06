using RaffleApp.Api.Auth.Entities;
using RaffleApp.Api.Raffles.Entities;

namespace RaffleApp.Api.Winners.Entities;

public class RaffleWinnerHistory
{
    public int Id { get; set; }
    public int RaffleId { get; set; }
    public Raffle? Raffle { get; set; }
    public required string WinnerUserId { get; set; }
    public ApplicationUser? WinnerUser { get; set; }
    public DateTimeOffset SelectedAt { get; set; }
    public required string SelectedByUserId { get; set; }
    public ApplicationUser? SelectedByUser { get; set; }
}