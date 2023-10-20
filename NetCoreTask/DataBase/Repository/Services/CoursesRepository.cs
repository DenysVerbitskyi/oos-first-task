using Mapster;

using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models;

namespace NetCoreTask.DataBase.Repository.Services;

public class CoursesRepository : RepositoryBase<CourseEntity, UniversityDbContext>
{
    private readonly UniversityDbContext _context;
    public CoursesRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<CourseEntity> GetById(int id)
    {
        return await _context.Courses
            .Include(c => c.Teacher)
            .AsNoTracking()
            .FirstAsync(s => s.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<List<CourseEntity>> GetAll()
    {
        return await _context.Courses
            .Include(c => c.Teacher)
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }
}