using System.ComponentModel;

namespace SM_Horarios;

public class EmployeeDTO
{
    public string? Name { get; set; }

    [PasswordPropertyText]
    public string? Password { get; set; }
}
