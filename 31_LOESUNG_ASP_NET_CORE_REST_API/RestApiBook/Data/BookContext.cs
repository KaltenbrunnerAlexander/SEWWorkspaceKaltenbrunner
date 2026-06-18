// NEU HINZUGEFÜGT (Aufgabe 1c): BookContext - Entity Framework DbContext
// Verbindet die Anwendung mit der SQLite-Datenbank.
// Würde normalerweise durch Scaffolding in Visual Studio automatisch generiert.

using Microsoft.EntityFrameworkCore;
using RestApiBook.Models;

namespace RestApiBook.Data
{
    public class BookContext : DbContext
    {
        // Konstruktor nimmt DbContextOptions entgegen (wird via Dependency Injection befüllt)
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        // DbSet repräsentiert die "Books"-Tabelle in der Datenbank
        public DbSet<Book> Books { get; set; } = default!;
    }
}
