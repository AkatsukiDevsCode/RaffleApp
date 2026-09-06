using Microsoft.AspNetCore.Identity;

namespace RaffleApp.Api.Auth.Entities;

public class ApplicationUser : IdentityUser
{
    public required string DiscordId { get; set; }
    public required string DiscordUsername { get; set; }
    public string? DiscordGlobalName { get; set; }
    public string? DiscordAvatarUrl { get; set; }
    public string? DiscordAccessTokenEncrypted { get; set; }
    public string? DiscordRefreshTokenEncrypted { get; set; }
    public DateTimeOffset? DiscordTokenExpiresAt { get; set; }
    public DateTimeOffset? LastLoginAt { get; set; }
}