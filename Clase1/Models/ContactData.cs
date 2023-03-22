using System.ComponentModel.DataAnnotations;

public class ContactData
{
    // Este atributo indica que el nombre es obligatorio
    [Required]
    [Display(Name ="hola")]
    public string Name { get; set; }

    // Estos atributos indican que el correo electrónico es obligatorio y debe tener un formato válido
}