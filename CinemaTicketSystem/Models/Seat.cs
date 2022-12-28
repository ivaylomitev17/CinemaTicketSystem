namespace CinemaTicketSystem.Models
{
    public class Seat
    {
        public int SeatID { get; set; }
        public bool Availability { get; set; }
        public int ProjectionID { get; set; }
        public int? ReservationID { get; set; }
        public Projection Projection { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
