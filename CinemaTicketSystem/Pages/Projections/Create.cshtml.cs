using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Pages.Projections
{
    public class CreateModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public CreateModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieId", "Name");
            return Page();
        }

        [BindProperty]
        public Projection Projection { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var seats = Enumerable.Range(1, 50).Select(n => new Seat() { Number = n, Availability = true });
            Projection.SeatsAvailability = seats.ToList();

            _context.Projection.Add(Projection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
