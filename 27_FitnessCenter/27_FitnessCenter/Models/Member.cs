namespace _27_FitnessCenter.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public List<Booking> Bookings { get; set; } = new(); 
}