namespace NetCoreTask.Services.Abstractions;

/// <summary>
/// Contains methods to map objects belonging to dissimilar types.
/// </summary>
public interface IDataMapper
{
    /// <summary>
    /// Deep copy
    /// </summary>
    TSource Clone<TSource>(TSource source);

    /// <summary>
    /// Mappes one type to another
    /// </summary>
    TDes Map<TSource, TDes>(TSource source);

    /// <summary>
    /// Mappes one type to another
    /// </summary>
    TDes Map<TDes>(object source);
}