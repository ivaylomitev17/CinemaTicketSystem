using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<CinemaTicketSystem.Models.Movie> Movie { get; set; } = default!;
    }
}
