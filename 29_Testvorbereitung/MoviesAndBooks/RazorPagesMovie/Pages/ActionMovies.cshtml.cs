using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class ActionMoviesModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public ActionMoviesModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> ActionMovies { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Holt über LINQ filternd nur Filme mit dem Genre "Action" aus der DB
            ActionMovies = await _context.Movie
                .Where(m => m.Genre == "Action")
                .ToListAsync();
        }
    }
}