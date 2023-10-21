using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models.Dto;

namespace NetCoreTask.Services;

public class StudentsService : ApiService<StudentEntity, StudentDto>
{
    public StudentsService(IRepository<StudentEntity> repository, ILogger<ApiService<StudentEntity, StudentDto>> logger)
        : base(repository, logger)
    {

    }
}
