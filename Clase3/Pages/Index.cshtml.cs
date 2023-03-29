using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Clase3.Models;
using Clase3.Services;

namespace Clase3.Pages;

public class IndexModel : PageModel
{
    public List<Movie> MovieList{ get; set;}
    
    [BindProperty]
    public Movie NewMovie { get; set; }

    public IndexModel()
    {
        // Constructor
    }

    public void OnGet()
    {
        MovieList = MovieService.GetAll();
    }

    public IActionResult OnPost(){
        if(!ModelState.IsValid){
            return RedirectToPage("/Error");
        }
        
        MovieService.Add(NewMovie);

        return RedirectToAction("get");
    }
}
