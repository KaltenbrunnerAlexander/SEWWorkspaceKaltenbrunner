// NEU HINZUGEFÜGT (Aufgabe 1c): Book Model-Klasse
// Repräsentiert ein Buch in der Datenbank.
// Wird von Entity Framework Core für die SQLite-Datenbank verwendet.

namespace RestApiBook.Models
{
    public class Book
    {
        // Primärschlüssel (Id) - wird von EF Core automatisch als Auto-Increment behandelt
        public int Id { get; set; }

        // Titel des Buches
        public string? Title { get; set; }

        // Autor des Buches
        public string? Author { get; set; }
    }
}
