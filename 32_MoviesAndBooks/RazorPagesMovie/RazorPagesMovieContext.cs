// GEÄNDERT (Aufgabe 2c): Actor-DbSet hinzugefügt
// Nach dieser Änderung in Package Manager Console:
//   Add-Migration AddActor
//   Update-Database
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

public class RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) : DbContext(options)
{
    public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;

    // NEU (Aufgabe 2c): DbSet für Actors → repräsentiert die "Actor"-Tabelle
    public DbSet<Actor> Actor { get; set; } = default!;
}
