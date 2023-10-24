using System.Runtime.CompilerServices;

using Mapster;

using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Abstraction;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models.Abstractions;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask.Services;

public abstract class ApiService<TEntity, TDto> : IApiService<TDto>
    where TEntity : class, IEntity
    where TDto : class, IDto
{
    private readonly IRepository<TEntity> _repository;
    private readonly ILogger<ApiService<TEntity, TDto>> _logger;
    private readonly string _entityName;

    public ApiService(IRepository<TEntity> repository, ILogger<ApiService<TEntity, TDto>> logger)
    {
        _repository = repository;
        _logger = logger;
        _entityName = typeof(TDto).Name.Substring(0, typeof(TDto).Name.IndexOf("Dto"));
    }
    public virtual async Task<TDto> Add(TDto dto)
    {
        _logger.LogDebug($"Started creation of a new {_entityName}");
        
        var entity = await RequestDataAsync(_repository.Add(dto.Adapt<TEntity>()));

        _logger.LogDebug($"{_entityName} with id:{dto.Id} was created.");

        return entity.Adapt<TDto>();
    }

    public virtual async Task<TDto> Delete(Guid id)
    {
        _logger.LogDebug($"Started deleting {_entityName} with id:{id}");

        var entity = await RequestDataAsync(_repository.Delete(id));

        _logger.LogDebug($"Deleting {_entityName} with id:{id} was successfully");

        return entity.Adapt<TDto>();
    }

    public virtual async Task<List<TDto>> GetAll()
    {
        _logger.LogDebug($"Started getting all {_entityName}'s from database");

        var entities = await RequestDataAsync(_repository.GetAll());
        
        _logger.LogDebug($"All {_entityName}'s were successfully getted.");

        return entities.Adapt<List<TDto>>();
    }

    public virtual async Task<TDto> GetById(Guid id)
    {
        _logger.LogDebug($"Started getting {_entityName} with id:{id} from database");

        var entity = await RequestDataAsync(_repository.GetById(id));

        _logger.LogDebug($"{_entityName} with id:{id} was successfully getted");

        return entity.Adapt<TDto>();
    }

    public virtual async Task<TDto> Update(TDto dto)
    {
        var entity = await RequestDataAsync(_repository.Update(dto.Adapt<TEntity>()));

        return entity.Adapt<TDto>();
    }

    private async Task<T> RequestDataAsync<T>(Task<T> task, [CallerMemberName] string? name = null)
    {
        try
        {
            var response = await task.ConfigureAwait(false);

            return response;
        }
        catch (InvalidOperationException ioe)
        {
            _logger.LogError(ioe, "The requested resource from method {Method} is not found on the server", name);

            throw;
        }
        catch (ArgumentNullException ane)
        {
            _logger.LogError(ane, "Invalid argument from method {Method}", name);

            throw;
        }
        catch (DbUpdateException dbue)
        {
            _logger.LogError(dbue, "Cannot add or update entity on server. From method {Method} ", name);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unknown Exception in ApiService in {Method}", name);

            throw;
        }
    }

    private async Task RequestDataAsync(Task task, [CallerMemberName] string? name = null)
    {
        try
        {
            await task.ConfigureAwait(false);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Unknown Exception in ApiService in {Method}", name);

            throw;
        }
    }
}
