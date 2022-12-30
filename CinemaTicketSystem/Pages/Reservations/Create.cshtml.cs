using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace CinemaTicketSystem.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;

        public CreateModel(CinemaTicketSystem.Data.CinemaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projection == null)
            {
                return NotFound();
            }

            Projection = await _context.Projection.FirstOrDefaultAsync(m => m.ProjectionId == id);
            if (Projection == null)
            {
                return NotFound();
            }

            Seats = _context.Seat.Where(m => m.ProjectionId == id).ToList();

            //ViewData["MovieID"] = new SelectList(_context.Movie, "MovieId", "MovieId");
            //return Page();




            ViewData["ProjectionId"] = new SelectList(_context.Projection, "ProjectionId", "ProjectionId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SeatId"] = new SelectList(Seats, "SeatId", "SeatId");
            return Page();
        }
        [BindProperty]
        public Projection Projection { get; set; }
        [BindProperty]
        public ICollection<Seat> Seats { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }

        //public ICollection<Seat> ReservedSeats { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Reservation Reservation, int? id, List<int> SeatsList)
        {
            List<Seat> ReservedSeats = new List<Seat>();
            Seats = _context.Seat.Where(m => m.ProjectionId == id).ToList();
            foreach (var reservedSeatId in SeatsList)
            {
                var reservedSeat = (from x in Seats
                                    where x.SeatId == reservedSeatId
                                    select x).FirstOrDefault();
                if (null != reservedSeat)
                {
                    reservedSeat.Availability = false;
                    _context.Attach(reservedSeat).State = EntityState.Modified;
                    ReservedSeats.Add(reservedSeat);
                    
                }
            }
            Reservation.Seats = ReservedSeats;

            //if (!ModelState.IsValid)
            //{
           //     return Page();
           // }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void seatClick()
        {

        }




    }
}
