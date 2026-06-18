// NEU (Aufgabe 1c): DbContext für die SQLite-Datenbank
using Microsoft.EntityFrameworkCore;
using RestApiBook.Models;

namespace RestApiBook.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        // Repräsentiert die "Books"-Tabelle
        public DbSet<Book> Books { get; set; } = default!;
    }
}
