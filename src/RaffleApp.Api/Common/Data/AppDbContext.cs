using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaffleApp.Api.Auth.Entities;
using RaffleApp.Api.Participations.Entities;
using RaffleApp.Api.Raffles.Entities;
using RaffleApp.Api.Winners.Entities;

namespace RaffleApp.Api.Common.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Raffle> Raffles => Set<Raffle>();

    public DbSet<RaffleEntry> RaffleEntries => Set<RaffleEntry>();

    public DbSet<RaffleWinnerHistory> RaffleWinnerHistories => Set<RaffleWinnerHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.ApplySoftDeleteQueryFilter();
    }
}