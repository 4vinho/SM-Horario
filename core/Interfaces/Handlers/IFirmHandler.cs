using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IFirmHandler : IGenericRepositoryHandler<Firm>
{
    public Task<PagedResponse<IEnumerable<Firm>?>> GetByNameAsync(
        string name,
        PagedRequest pagedRequest
    );
}
