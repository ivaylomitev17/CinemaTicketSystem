namespace CinemaTicketSystem.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int Number { get; set; }
        public bool Availability { get; set; }
        public int ProjectionId { get; set; }
        public int? ReservationId { get; set; }
        public Projection Projection { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
