using Microsoft.EntityFrameworkCore;
using RestApiDestinations.Controllers;
using RestApiDestinations.Models;

namespace RestApiDestinations.Data
{
    public class DefinitionContext : DbContext
    {
        public DefinitionContext(DbContextOptions<Definition> options) : base(options) { }

        public DbSet<Definition> Definition { get; set; } = default!;
    }
}
