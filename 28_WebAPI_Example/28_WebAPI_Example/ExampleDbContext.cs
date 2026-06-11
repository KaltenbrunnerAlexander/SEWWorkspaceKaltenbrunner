using _28_WebAPI_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace _28_WebAPI_Example
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions <ExampleDbContext> options) : base(options) { }
        public DbSet<Rechnung> Rechnungen { get; set; } //Model Klasse
    }
}
