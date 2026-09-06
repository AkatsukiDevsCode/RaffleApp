using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaffleApp.Api.Auth.Entities;

namespace RaffleApp.Api.Auth.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.DiscordId).HasMaxLength(32);
        builder.HasIndex(u => u.DiscordId).IsUnique();

        builder.Property(u => u.DiscordUsername).HasMaxLength(100);
        builder.Property(u => u.DiscordGlobalName).HasMaxLength(100);
        builder.Property(u => u.DiscordAvatarUrl).HasMaxLength(500);
    }
}