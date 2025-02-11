namespace SM_Horarios;

public class MarkedTime
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int FirmId { get; set; }
    public Firm? Firm { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }
}
