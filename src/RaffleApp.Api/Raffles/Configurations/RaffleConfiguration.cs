using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaffleApp.Api.Auth.Configurations;
using RaffleApp.Api.Raffles.Entities;

namespace RaffleApp.Api.Raffles.Configurations;

public class RaffleConfiguration : IEntityTypeConfiguration<Raffle>
{
    public void Configure(EntityTypeBuilder<Raffle> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title).HasMaxLength(150);

        builder.Property(r => r.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property<uint>("xmin").IsRowVersion();

        builder.HasOne(r => r.Winner)
            .WithMany()
            .HasForeignKey(r => r.WinnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => new { r.IsActive, r.StartDate, r.EndDate });

        builder.ConfigureAuditForeignKeys();
    }
}