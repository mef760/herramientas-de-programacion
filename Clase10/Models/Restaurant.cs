
namespace Clase6.Models;

public class Restaurant 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }

    public virtual List<Menu> Menus { get; set; }
}