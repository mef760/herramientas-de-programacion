using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase2.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    [BindProperty]
    public Form Data { get; set; }

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var parametro = Request.Query["id"];

        //buscar en la base de datos el formulario con id que esta en el parametro
        // var formulario = servicioFormulario.get(parametro);

        Data = new Form();
        Data.Mail = parametro;
        Data.Password = "12345";
    }

    public IActionResult OnPost(){
        if (!ModelState.IsValid){
            return Page();
        }
        // guardar en la base datos, procesar informacion
        var formValues = Data;

        return RedirectToPage("Index");
    }
}

