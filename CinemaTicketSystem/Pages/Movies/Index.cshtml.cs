using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.MoviesContext _context;

        public IndexModel(CinemaTicketSystem.Data.MoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
