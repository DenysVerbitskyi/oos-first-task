using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.DataBase.Repository;

public class CourseRepository : RepositoryBase<CourseEntity, UniversityDbContext>, ICourseRepository
{
    private readonly UniversityDbContext _context;
    public CourseRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<CourseEntity> GetById(int id)
    {
        return await _context.Courses
            .Include(c => c.Teacher)
            .AsNoTracking()
            .FirstAsync(s => s.Id == id);
    }

    public override async Task<List<CourseEntity>> GetAll()
    {
        return await _context.Courses
            .Include(c => c.Teacher)
            .AsNoTracking()
            .ToListAsync();
    }
}