using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages.MoviePages
{
    public class MovieClassifierModel : PageModel
    {
        [BindProperty]
        public int Duration { get; set; }

        public string Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Duration >= 0 && Duration <= 5)
            {
                Result = "Werbung";
            }
            else if (Duration <= 50)
            {
                Result = "Serie";
            }
            else
            {
                Result = "Spielfilm";
            }
        }
    }
}
