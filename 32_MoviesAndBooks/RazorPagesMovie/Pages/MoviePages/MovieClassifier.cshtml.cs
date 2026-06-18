// NEU (Aufgabe 2d): Server-seitige Klassifizierung der Filmdauer
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class MovieClassifierModel : PageModel
    {
        // [BindProperty] verbindet die Formulareingabe automatisch mit dieser Property
        [BindProperty]
        public int DurationMinutes { get; set; }

        // Speichert das Klassifizierungsergebnis für die Anzeige in der View
        public string? Classification { get; set; }

        // GET: Seite wird geöffnet – noch keine Klassifizierung
        public void OnGet()
        {
            Classification = null;
        }

        // POST: Formular wurde abgesendet → server-seitig klassifizieren
        public void OnPost()
        {
            // AUFGABE 2d: Klassifizierungslogik
            // 0–5 Min    → Werbung
            // >5–50 Min  → Serie
            // >50 Min    → Spielfilm
            if (DurationMinutes >= 0 && DurationMinutes <= 5)
                Classification = "Werbung";
            else if (DurationMinutes > 5 && DurationMinutes <= 50)
                Classification = "Serie";
            else if (DurationMinutes > 50)
                Classification = "Spielfilm";
            else
                Classification = "Ungültige Eingabe";
        }
    }
}
