using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models;

namespace NetCoreTask.Services;

public class TeachersService : ApiService<TeacherEntity, TeacherDto>
{
    public TeachersService(IRepository<TeacherEntity> repository, ILogger<ApiService<TeacherEntity, TeacherDto>> logger)
        : base(repository, logger)
    {
    }
}
