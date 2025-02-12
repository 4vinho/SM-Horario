using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IClientHandler : IGenericRepositoryHandler<Client>
{
    public ActionResult<IEnumerable<Client>> GetClientByNameAsync(string clientName);
}
