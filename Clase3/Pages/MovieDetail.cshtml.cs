using Clase3.Models;
using Clase3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase3.Pages
{
    public class MovieDetailModel : PageModel
    {
        public Movie MovieDetail { get; set; } = new();
        public void OnGet(string code)
        {
            if (code != null){
                var responseServiceData = MovieService.Get(code);
                if(responseServiceData != null){
                    MovieDetail = responseServiceData;
                }
            }
        }

        public IActionResult OnPostDelete(string code){
            if(code != null){
                MovieService.Delete(code);
            }

            return RedirectToPage("Index");
        }
    }
}
