using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IClientHandler : IGenericRepositoryHandler<Client>
{
    public Response<IEnumerable<Client>> GetClientByNameAsync(string clientName);
}
