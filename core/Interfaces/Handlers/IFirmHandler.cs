using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IFirmHandler : IGenericRepositoryHandler<Firm>
{
    public Response<IEnumerable<Firm>> GetByNameAsync(string name);
    public Response<IEnumerable<int>> GetEmployeeAsync(int firmId);
}
