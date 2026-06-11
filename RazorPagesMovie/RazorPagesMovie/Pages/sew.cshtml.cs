using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages
{
    public class sewModel : PageModel
    {
        [BindProperty]
        public int Number1 { get; set; }

        [BindProperty]
        public int Number2 { get; set; }
        public int Result { get; set; } = 42;
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Result = Number1 + Number2;
            return Page();
        }
    }
}
