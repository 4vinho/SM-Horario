using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IMarkedTimeHandler : IGenericRepositoryHandler<MarkedTimeDTO>
{
    public Response<IEnumerable<MarkedTimeDTO>> GetByFirmIdAsync(int firmId);
    public Response<IEnumerable<MarkedTimeDTO>> GetByEmployeeIdAsync(int employeeId);
    public Response<IEnumerable<MarkedTimeDTO>> GetByClientIdAsync(int clientId);
}
