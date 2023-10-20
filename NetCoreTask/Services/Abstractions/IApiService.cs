﻿namespace NetCoreTask.Services.Abstractions;

public interface IApiService<T>
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}
