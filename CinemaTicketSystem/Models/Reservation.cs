namespace CinemaTicketSystem.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int ProjectionID { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public Projection Projection { get; set; }


    }
}
