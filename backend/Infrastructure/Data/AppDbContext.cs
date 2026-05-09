using Core.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<
        AppUser,
        AppRole,
        long,
        IdentityUserClaim<long>,
        AppUserRole,
        IdentityUserLogin<long>,
        IdentityRoleClaim<long>,
        IdentityUserToken<long>
    >(options)
{
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        builder.Entity<Hotel>(e =>
        {
            e.Property(h => h.PricePerNight).HasColumnType("decimal(10,2)");
        });

        builder.Entity<Booking>(e =>
        {
            e.Property(b => b.TotalPrice).HasColumnType("decimal(10,2)");
            e.HasOne(b => b.Hotel)
             .WithMany(h => h.Bookings)
             .HasForeignKey(b => b.HotelId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
