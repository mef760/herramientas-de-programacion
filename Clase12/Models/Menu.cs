using Clase6.Utils;

namespace Clase6.Models;

public class Menu 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MenuType Type { get; set; }
    public bool IsVegetarian { get; set; } = false;
    public int Calories { get; set; }

    public virtual List<Restaurant> Restaurants { get; set; }
}