using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SM_Horarios;

public class ClientDTO
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }
}
