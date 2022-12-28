namespace CinemaTicketSystem.Models
{
    public enum Rating
    {
        G,
        PG,
        R,
        X

    }
    public class Movie
    {
        public int MovieID { get; set; }
        public String Name { get; set; }
        public int Duration { get; set; }
        public Rating Rating { get; set; }
        public ICollection<Projection>? Projections { get; set; }

    }
}
