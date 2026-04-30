namespace _27_FitnessCenter.Models;

public class Course
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty; 
    public DateTime Time { get; set; } 
    public int DurationMinutes { get; set; } 
    public int MaxParticipants { get; set; } 
    public List<Booking> Bookings { get; set; } = new(); 
}