using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.ActorPages;

public class DetailsModel : PageModel
{
    private readonly RazorPagesMovieContext _context;
    public DetailsModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    public Actor Actor { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var actor = await _context.Actor.FirstOrDefaultAsync(m => m.Id == id);
        if (actor is null)
        {
            return NotFound();
        }
        else
        {
            Actor = actor;
        }

        return Page();
    }
}
