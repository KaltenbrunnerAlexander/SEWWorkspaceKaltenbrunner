// NEU HINZUGEFÜGT (Aufgabe 2b): Code-Behind für die ActionMovies Razor Page
// Lädt nur Filme mit Genre "Action" aus der Datenbank.

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class ActionMoviesModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        // Konstruktor - Context wird per Dependency Injection injiziert
        public ActionMoviesModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        // Liste der Action-Filme die in der View angezeigt werden
        public IList<Movie> Movie { get; set; } = default!;

        // OnGetAsync: Wird bei jedem GET-Request auf diese Seite aufgerufen
        public async Task OnGetAsync()
        {
            // AUFGABE 2b: Nur Filme mit Genre "Action" laden (Where-Klausel als Filter)
            Movie = await _context.Movie
                .Where(m => m.Genre == "Action")
                .ToListAsync();
        }
    }
}
