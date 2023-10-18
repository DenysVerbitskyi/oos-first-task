using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.DataBase.Repository;

public class StudentsRepository : RepositoryBase<StudentEntity, UniversityDbContext>, IStudentRepository
{
    private readonly UniversityDbContext _context;
    public StudentsRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<StudentEntity> GetById(int id)
    {
        return await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .ThenInclude(c => c.Teacher)
            .AsNoTracking()
            .FirstAsync(s => s.Id == id);
    }

    public override async Task<List<StudentEntity>> GetAll()
    {
        return await _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .ThenInclude(c => c.Teacher)
            .AsNoTracking()
            .ToListAsync();
    }
}
