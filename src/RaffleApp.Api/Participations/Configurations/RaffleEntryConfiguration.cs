using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaffleApp.Api.Auth.Configurations;
using RaffleApp.Api.Participations.Entities;

namespace RaffleApp.Api.Participations.Configurations;

public class RaffleEntryConfiguration : IEntityTypeConfiguration<RaffleEntry>
{
    public void Configure(EntityTypeBuilder<RaffleEntry> builder)
    {
        builder.HasKey(e => new { e.RaffleId, e.UserId });

        builder.HasOne(e => e.Raffle)
            .WithMany()
            .HasForeignKey(e => e.RaffleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.UserId).HasDatabaseName("idx_raffleentries_userid");

        builder.ConfigureAuditForeignKeys();
    }
}