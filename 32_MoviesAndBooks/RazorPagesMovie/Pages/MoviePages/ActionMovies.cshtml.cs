// NEU (Aufgabe 2b): Lädt nur Filme mit Genre "Action" aus der Datenbank
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class ActionMoviesModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public ActionMoviesModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // AUFGABE 2b: Nur Action-Filme laden
            Movie = await _context.Movie
                .Where(m => m.Genre == "Action")
                .ToListAsync();
        }
    }
}
