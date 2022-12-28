using CinemaTicketSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Projection> Projection { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}