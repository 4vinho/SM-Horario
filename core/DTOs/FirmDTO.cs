using System.ComponentModel;

namespace SM_Horarios;

public class FirmDTO
{
    public string? Name { get; set; }

    [PasswordPropertyText]
    public string? Password { get; set; }
    public int FirmId { get; set; }
}
