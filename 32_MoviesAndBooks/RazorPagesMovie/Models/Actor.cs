// NEU (Aufgabe 2c): Actor Model-Klasse
// Nach dem Erstellen: Scaffolding in VS für CRUD-Seiten verwenden
// Rechtsklick auf Pages → Add → New Scaffolded Item →
// Razor Pages using Entity Framework (CRUD) → Model: Actor, DbContext: RazorPagesMovieContext
using System.ComponentModel;

namespace RazorPagesMovie.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [DisplayName("Vorname")]
        public string? Vorname { get; set; }

        [DisplayName("Nachname")]
        public string? Nachname { get; set; }
    }
}
