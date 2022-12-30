using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;

namespace CinemaTicketSystem.Pages.Reservations
{
    public class DeleteModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public DeleteModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FirstOrDefaultAsync(m => m.ReservationId == id);

            if (reservation == null)
            {
                return NotFound();
            }
            else 
            {
                Reservation = reservation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservation.FindAsync(id);
            var seatList = _context.Seat.Where(m => m.ReservationId == id).ToList();
            
            foreach(var seat in seatList)
            {
                seat.Availability = true;
                _context.Attach(seat).State = EntityState.Modified;
                seat.Reservation = null;
                seat.ReservationId = null;
            }
            

            if (reservation != null)
            {
                Reservation = reservation;
                _context.Reservation.Remove(Reservation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
