using _27_FitnessCenter.Models;
using Microsoft.EntityFrameworkCore;

public class FitnessContext : DbContext
{
    public FitnessContext(DbContextOptions<FitnessContext> options) : base(options) { }

    public DbSet<Member> Members { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}