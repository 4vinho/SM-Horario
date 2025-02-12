using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IEmployeeHandler : IGenericRepositoryHandler<Employee>
{
    public Response<IEnumerable<Employee>> GetEmployeeByFirmAsync(int firmId);
}
