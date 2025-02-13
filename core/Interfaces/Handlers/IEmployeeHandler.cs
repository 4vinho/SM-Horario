using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IEmployeeHandler : IGenericRepositoryHandler<EmployeeDTO>
{
    public Task<PagedResponse<IEnumerable<EmployeeDTO>?>> GetEmployeesByFirmIdAsync(
        int firmId,
        PagedRequest pagedRequest
    );
}
