using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Pages.Projections
{
    public class EditModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public EditModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projection Projection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projection == null)
            {
                return NotFound();
            }

            var projection =  await _context.Projection.FirstOrDefaultAsync(m => m.ProjectionId == id);
            if (projection == null)
            {
                return NotFound();
            }
            Projection = projection;
           ViewData["MovieID"] = new SelectList(_context.Movie, "MovieId", "MovieId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Projection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectionExists(Projection.ProjectionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectionExists(int id)
        {
          return _context.Projection.Any(e => e.ProjectionId == id);
        }
    }
}
