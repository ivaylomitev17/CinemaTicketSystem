namespace CinemaTicketSystem.Models
{
  
    public class Projection
    {
        public int ProjectionId { get; set; }
        public int MovieID { get; set; }
        public DateTime Time { get; set; }
        public Movie Movie { get; set; }
        public ICollection<Seat> SeatsAvailability { get; set; }
    }

}
