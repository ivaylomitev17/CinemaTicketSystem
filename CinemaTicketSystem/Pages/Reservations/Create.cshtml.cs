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
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace CinemaTicketSystem.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly CinemaTicketSystem.Data.CinemaContext _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager <ApplicationUser> _userManager;
        private  int projectionId;
        public CreateModel(CinemaTicketSystem.Data.CinemaContext context, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projection == null)
            {
                return NotFound();
               
            }
            //projectionId = id ?? default(int);
            Projection = await _context.Projection.FirstOrDefaultAsync(m => m.ProjectionId == id);
            if (Projection == null)
            {
                return NotFound();
            }

            Seats = _context.Seat.Where(m => m.ProjectionId == id).ToList();

            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieId", "MovieId");
            //return Page();

            ViewData["ProjectionId"] = new SelectList(_context.Projection, "ProjectionId", "ProjectionId",id);
            //ViewData["ProjectionId"] = id;
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            
            ViewData["SeatId"] = new SelectList(Seats, "SeatId", "SeatId");
            return Page();
        }
        
        public Projection Projection { get; set; }
        [BindProperty]
        public ICollection<Seat> Seats { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Reservation Reservation, int? id, List<int> SeatsList)
        {
 
            
            Reservation.User = await _userManager.GetUserAsync(User);
            Reservation.UserId = Reservation.User.Id;
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

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            var user = await _userManager.GetUserAsync(User);
            var movieTitle = (from projection in _context.Projection
                              where projection.ProjectionId == Reservation.ProjectionId
                              select projection.Movie.Name).First();
            StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("Thank you for reserving tickets for our cinema!\n Your seats is/are:\n");
            foreach (var reservedSeatId in ReservedSeats)
            {
                builder.Append(reservedSeatId.Number + "  ");
            }
            builder.Append("\n for the movie ");
            builder.Append(movieTitle);
                
            
            
            
            await _emailSender.SendEmailAsync(
                    user.Email,
                    "Successful Tickets Reservation",
                    builder.ToString());


            
            return RedirectToPage("../Projections/Index");
        }

        public void seatClick()
        {

        }




    }
}
