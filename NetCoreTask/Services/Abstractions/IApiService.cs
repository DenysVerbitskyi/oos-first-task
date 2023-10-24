namespace NetCoreTask.Services.Abstractions;

public interface IApiService<TDomain>
{
    Task<List<TDomain>> GetAll();
    Task<TDomain> GetById(Guid id);
    Task<TDomain> Add(TDomain entity);
    Task<TDomain> Update(TDomain entity);
    Task<TDomain> Delete(Guid id);
}
