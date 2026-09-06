using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaffleApp.Api.Winners.Entities;

namespace RaffleApp.Api.Winners.Configurations;

public class RaffleWinnerHistoryConfiguration : IEntityTypeConfiguration<RaffleWinnerHistory>
{
    public void Configure(EntityTypeBuilder<RaffleWinnerHistory> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasOne(w => w.Raffle)
            .WithMany()
            .HasForeignKey(w => w.RaffleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.WinnerUser)
            .WithMany()
            .HasForeignKey(w => w.WinnerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.SelectedByUser)
            .WithMany()
            .HasForeignKey(w => w.SelectedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(w => w.RaffleId);
    }
}