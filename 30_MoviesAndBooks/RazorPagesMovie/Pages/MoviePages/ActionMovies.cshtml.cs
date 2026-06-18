using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

public class ActionMoviesModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public ActionMoviesModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IList<Movie> ActionMovies { get; set; }

    public async Task OnGetAsync()
    {
        ActionMovies = await _context.Movie
            .Where(m => m.Genre == "Action")
            .ToListAsync();
    }
}