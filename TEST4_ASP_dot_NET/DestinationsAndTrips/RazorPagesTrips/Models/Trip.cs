namespace RazorPagesTrips.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public int Days { get; set; } //in Ganztagen
        public double Price { get; set; } //in Euro
    }
}
