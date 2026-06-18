// GEÄNDERT (Aufgabe 2c): Actor-DbSet wurde hinzugefügt
// Ermöglicht CRUD-Operationen für Actors in der Datenbank.
// Nach dieser Änderung in Visual Studio:
// 1. Add-Migration AddActor (in Package Manager Console)
// 2. Update-Database (um die Datenbank zu aktualisieren)

using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

public class RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options) : DbContext(options)
{
    // Bereits vorhanden: DbSet für Movies
    public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;

    // NEU HINZUGEFÜGT (Aufgabe 2c): DbSet für Actors
    // Repräsentiert die "Actors"-Tabelle in der Datenbank.
    // Wird für die durch Scaffolding generierten CRUD-Seiten benötigt.
    public DbSet<Actor> Actor { get; set; } = default!;
}
