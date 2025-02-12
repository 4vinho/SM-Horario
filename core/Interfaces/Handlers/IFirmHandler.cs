using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IFirmHandler : IGenericRepositoryHandler<Firm>
{
    public ActionResult<IEnumerable<Firm>> GetByNameAsync(string name);
    public ActionResult<IEnumerable<int>> GetEmployeeAsync(int firmId);
}
