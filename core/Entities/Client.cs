namespace SM_Horarios;

public class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public ICollection<MarkedTime>? MarkedTime { get; set; }
}
