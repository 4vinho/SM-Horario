namespace SM_Horarios;

public interface IMarkedTimeHandler : IGenericRepositoryHandler<MarkedTimeDTO>
{
    public ActionResult<IEnumerable<MarkedTimeDTO>> GetByFirmIdAsync(int firmId);
    public ActionResult<IEnumerable<MarkedTimeDTO>> GetByEmployeeIdAsync(int employeeId);
    public ActionResult<IEnumerable<MarkedTimeDTO>> GetByClientIdAsync(int clientId);
}
