using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Pages.Projections
{
    public class IndexModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public IndexModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

        public IList<Projection> Projection { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Projection != null)
            {
                Projection = await _context.Projection
                .Include(p => p.Movie).ToListAsync();
            }
        }
    }
}
