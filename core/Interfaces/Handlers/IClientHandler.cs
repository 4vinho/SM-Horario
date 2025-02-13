using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IClientHandler : IGenericRepositoryHandler<ClientDTO>
{
    public Task<PagedResponse<IEnumerable<ClientDTO>?>> GetClientByNameAsync(
        string clientName,
        PagedRequest pagedRequest
    );
}
