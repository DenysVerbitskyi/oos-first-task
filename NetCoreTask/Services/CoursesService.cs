using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models.Dto;

namespace NetCoreTask.Services;

public class CoursesService : ApiService<CourseEntity, CourseDto>
{
    public CoursesService(IRepository<CourseEntity> repository, ILogger<ApiService<CourseEntity, CourseDto>> logger)
        : base(repository, logger)
    {
    }
}
