// NEU HINZUGEFÜGT (Aufgabe 2d): MovieClassifier Code-Behind
// Empfängt die Formulardaten (Filmdauer) und klassifiziert den Film server-seitig.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class MovieClassifierModel : PageModel
    {
        // AUFGABE 2d: BindProperty bindet die Formulareingabe an diese Property
        // Die Eigenschaft wird automatisch aus dem POST-Request befüllt.
        [BindProperty]
        public int DurationMinutes { get; set; }

        // AUFGABE 2d: Speichert das Klassifizierungsergebnis (wird in der View angezeigt)
        // Null bedeutet: noch keine Klassifizierung durchgeführt
        public string? Classification { get; set; }

        // OnGet: Wird bei einem GET-Request aufgerufen (Seite wird zum ersten Mal geöffnet)
        public void OnGet()
        {
            // Beim ersten Öffnen der Seite: keine Klassifizierung anzeigen
            Classification = null;
        }

        // OnPost: Wird bei einem POST-Request aufgerufen (Formular wurde abgesendet)
        public void OnPost()
        {
            // AUFGABE 2d: Server-seitige Klassifizierung anhand der Dauer
            // Logik laut Aufgabenstellung:
            // - 0 bis 5 Minuten (inkl.): Werbung
            // - > 5 bis 50 Minuten (inkl.): Serie
            // - > 50 Minuten: Spielfilm
            if (DurationMinutes >= 0 && DurationMinutes <= 5)
            {
                Classification = "Werbung";
            }
            else if (DurationMinutes > 5 && DurationMinutes <= 50)
            {
                Classification = "Serie";
            }
            else if (DurationMinutes > 50)
            {
                Classification = "Spielfilm";
            }
            else
            {
                // Ungültige Eingabe (z.B. negativer Wert)
                Classification = "Ungültige Eingabe - Dauer muss 0 oder größer sein";
            }
        }
    }
}
