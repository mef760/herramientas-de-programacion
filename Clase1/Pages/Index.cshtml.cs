using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    public string Name { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    // Este método se ejecuta al cargar la página
    public void OnGet()
    {
        Name = "curso";
    }

    public async Task<IActionResult> OnPostAsync()
{
    if (!ModelState.IsValid)
    {
        return Page();
    }

    if (Name != null){
        //algo
    }

    return RedirectToPage("./Index");
}
}
