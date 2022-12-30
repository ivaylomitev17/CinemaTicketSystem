using System.ComponentModel.DataAnnotations;

namespace CinemaTicketSystem.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string UserId { get; set; }
        [Required]        
        public ApplicationUser User { get; set; }
        public int ProjectionId { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public Projection Projection { get; set; }


    }
}
