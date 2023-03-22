using System.ComponentModel.DataAnnotations;

public class Form{
    [Required]
    [Display(Name = "Email")]
    public string Mail { get; set; }
    
    [Required]
    [Display(Name = "Contrasenia")]
    public string Password { get; set; }
}