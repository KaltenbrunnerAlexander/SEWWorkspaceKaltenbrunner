// NEU (Aufgabe 1c): Book Model-Klasse für SQLite-Datenbank
namespace RestApiBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}
