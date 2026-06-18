using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.ActorPages;

public class EditModel : PageModel
{
    private readonly RazorPagesMovieContext _context;

    public EditModel(RazorPagesMovieContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Actor = actor;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Actor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActorExists(Actor.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ActorExists(int id)
    {
        return _context.Actor.Any(e => e.Id == id);
    }
}
