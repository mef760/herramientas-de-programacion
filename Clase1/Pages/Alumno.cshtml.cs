using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase1.Pages;

public class AlumnoModel : PageModel
{
    private readonly ILogger<AlumnoModel> _logger;
    [BindProperty]
    public ContactData Data { get; set; }
    public AlumnoModel(ILogger<AlumnoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Data = new ContactData();
    }
}
