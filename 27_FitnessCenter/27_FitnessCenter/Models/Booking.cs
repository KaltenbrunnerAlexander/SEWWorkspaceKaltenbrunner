namespace _27_FitnessCenter.Models;

public class Booking
{
    public int Id { get; set; } 
    public int MemberId { get; set; } 
    public int CourseId { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}