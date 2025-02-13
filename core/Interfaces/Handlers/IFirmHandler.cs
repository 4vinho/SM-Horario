using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IFirmHandler : IGenericRepositoryHandler<FirmDTO>
{
    public Task<PagedResponse<IEnumerable<FirmDTO>?>> GetByNameAsync(
        string name,
        PagedRequest pagedRequest
    );
}
