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
    public class DetailsModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public DetailsModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

      public Projection Projection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projection == null)
            {
                return NotFound();
            }

            var projection = await _context.Projection.FirstOrDefaultAsync(m => m.ProjectionId == id);
            if (projection == null)
            {
                return NotFound();
            }
            else 
            {
                Projection = projection;
            }
            return Page();
        }
    }
}
