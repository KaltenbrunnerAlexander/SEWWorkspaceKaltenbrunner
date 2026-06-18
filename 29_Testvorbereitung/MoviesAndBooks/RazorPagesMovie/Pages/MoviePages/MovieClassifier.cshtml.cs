using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class MovieClassifierModel : PageModel
    {
        [BindProperty]
        public int Duration { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Klassifizierung laut Angabezettel
            if (Duration >= 0 && Duration <= 5) // 0-5min
            {
                ResultMessage = "Werbung";
            }
            else if (Duration > 5 && Duration <= 50) // >5 bis 50min
            {
                ResultMessage = "Serie";
            }
            else if (Duration > 50) // >50min
            {
                ResultMessage = "Spielfilm";
            }
            else
            {
                ResultMessage = "Ungültige Minutenanzahl!";
            }
        }
    }
}