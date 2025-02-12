using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IGenericRepositoryHandler<TData>
    where TData : class
{
    public ActionResult<TData> CreateTDataAsync(TData tData);
    public ActionResult<TData> DeleteByIdAsync(int id);
    public ActionResult<IEnumerable<TData>> GetByIdAsync(int id);
    public ActionResult<TData> UpdateByIdAsync(int id);
}
