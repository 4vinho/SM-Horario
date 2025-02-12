using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IEmployeeHandler : IGenericRepositoryHandler<Employee>
{
    public ActionResult<IEnumerable<Employee>> GetEmployeeByFirmAsync(int firmId);
}
