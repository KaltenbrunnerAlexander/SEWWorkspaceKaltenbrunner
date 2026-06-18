// NEU HINZUGEFÜGT (Aufgabe 2c): Actor Model-Klasse
// Repräsentiert einen Schauspieler in der Datenbank.
// Nach dem Erstellen dieser Klasse würde man in Visual Studio Scaffolding verwenden,
// um die CRUD-Seiten automatisch zu generieren.

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Actor
    {
        // Primärschlüssel (wird von EF Core automatisch als Auto-Increment behandelt)
        public int Id { get; set; }

        // AUFGABE 2c: Vorname des Schauspielers
        [DisplayName("Vorname")]
        public string? Vorname { get; set; }

        // AUFGABE 2c: Nachname des Schauspielers
        [DisplayName("Nachname")]
        public string? Nachname { get; set; }
    }
}
