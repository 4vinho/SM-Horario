using Microsoft.AspNetCore.Mvc;

namespace SM_Horarios;

public interface IGenericRepositoryHandler<TData>
    where TData : class
{
    public Task<Response<TData?>> CreateTDataAsync(TData tData);
    public Task<Response<TData?>> DeleteByIdAsync(int id);
    public Task<Response<TData?>> GetByIdAsync(int id);
    public Task<Response<TData?>> UpdateByIdAsync(int id, TData tData);
}
