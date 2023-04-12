using System.ComponentModel.DataAnnotations;

namespace Clase5.Models;

public class Car {
    public int Id { get; set; }
    [Display(Name="Marca")]
    public string Make { get; set; }
     [Display(Name="Modelo")]
    public string Model { get; set; }
    [Display(Name="Año")]
    public int Year {get; set;}
    [Display(Name="Patente")]
    public string Plate { get; set; }
    [Display(Name="Color")]
    public string Color{ get; set; }

}
