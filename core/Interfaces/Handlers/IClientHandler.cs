using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IClientHandler : IGenericRepositoryHandler<Client>
{
    public Task<PagedResponse<IEnumerable<Client>?>> GetClientByNameAsync(
        string clientName,
        PagedRequest pagedRequest
    );
}
