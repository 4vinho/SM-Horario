using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IMarkedTimeHandler : IGenericRepositoryHandler<MarkedTimeDTO>
{
    public Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByFirmIdAsync(
        int firmId,
        PagedRequest pagedRequest
    );
    public Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByEmployeeIdAsync(
        int employeeId,
        PagedRequest pagedRequest
    );
    public Task<PagedResponse<IEnumerable<MarkedTimeDTO>?>> GetByClientIdAsync(
        int clientId,
        PagedRequest pagedRequest
    );
}
