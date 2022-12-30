using CinemaTicketSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketSystem.Data;

public class CinemaContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Projection> Projection { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Seat> Seat { get; set; }
    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
