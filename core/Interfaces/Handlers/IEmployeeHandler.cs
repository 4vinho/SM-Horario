using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IEmployeeHandler : IGenericRepositoryHandler<Employee>
{
    public Task<PagedResponse<IEnumerable<Employee>?>> GetEmployeesByFirmAsync(
        int firmId,
        PagedRequest pagedRequest
    );
}
