using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IGenericRepositoryHandler<TData>
    where TData : class
{
    public Response<TData> CreateTDataAsync(TData tData);
    public Response<TData> DeleteByIdAsync(int id);
    public Response<IEnumerable<TData>> GetByIdAsync(int id);
    public Response<TData> UpdateByIdAsync(int id);
}
