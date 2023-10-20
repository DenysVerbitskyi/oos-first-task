using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.DataBase.Repository.Services;

public class StudentsRepository : RepositoryBase<StudentEntity, UniversityDbContext>
{
    private readonly UniversityDbContext _context;
    public StudentsRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<StudentEntity> GetById(Guid id)
    {
        var student = await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .ThenInclude(c => c.Teacher)
            .AsNoTracking()
            .FirstAsync(s => s.Id == id)
            .ConfigureAwait(false);

        return student;
    }

    public override async Task<List<StudentEntity>> GetAll()
    {
        var student = await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .ThenInclude(c => c.Teacher)
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);

        return student;
    }
}
