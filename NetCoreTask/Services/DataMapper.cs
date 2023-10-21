using FastExpressionCompiler;

using Mapster;

using MapsterMapper;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.Models.Dto;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask.Client.Services;

public class DataMapper : IDataMapper
{
    private readonly Lazy<Mapper> _localMapper;
    public Mapper LocalMapper => _localMapper.Value;
    private static DataMapper _instance;
    private static TypeAdapterConfig _cfg;

    public static DataMapper Current => _instance ??= new DataMapper();

    public DataMapper()
    {
        _localMapper = new Lazy<Mapper>(() => new Mapper(_cfg ??= Config()));
    }

    public TSource Clone<TSource>(TSource source)
    {
        return LocalMapper.Map<TSource, TSource>(source);
    }

    public TDes Map<TSource, TDes>(TSource source)
    {
        return LocalMapper.Map<TSource, TDes>(source);
    }

    public TDes Map<TDes>(object source)
    {
        return LocalMapper.Map<TDes>(source);
    }

    private TypeAdapterConfig Config()
    {
        var cfg = TypeAdapterConfig.GlobalSettings;

        cfg.Compiler = static exp => exp.CompileFast();

        cfg.RequireDestinationMemberSource = true;
        cfg.Default.PreserveReference(true);

        RegisterDtoToEntityAndBack(cfg);

        //#if DEBUG
        try
        {
            cfg.Compile();
        }
        catch (Exception ex)
        {
            //ToDo: add logger here
        }
        //#endif

        return cfg;
    }

    private static void RegisterDtoToEntityAndBack(TypeAdapterConfig cfg)
    {
        cfg.NewConfig<CourseDto, CourseEntity>()
            .TwoWays();

        cfg.NewConfig<StudentDto, StudentEntity>()
           .TwoWays();

        cfg.NewConfig<TeacherDto, TeacherEntity>()
           .TwoWays();
    }

    private static DateTime? NullableDateTimeOffsetToNullableDateTime(DateTimeOffset? dateTimeOffset)
    {
        return dateTimeOffset?.LocalDateTime;
    }
}