using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Clase1.Pages
{
    public class ProfesorModel : PageModel
    {
        public List<ContactData> Lista { get; set; } = new List<ContactData>();
        [BindProperty]
        public ContactData Data {get;set;} 
        public void OnGet()
        {
            string parametro1 = Request.Query["parametro1"];
            Lista = DataService.GetAll();
        }

        public IActionResult OnPost(){
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DataService.Add(Data);
            return RedirectToAction("Get");
        }


    }
}
