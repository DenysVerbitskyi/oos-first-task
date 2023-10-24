using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.DataBase.Repository.Services;

public class TeachersRepository : RepositoryBase<TeacherEntity, UniversityDbContext>
{
    private readonly UniversityDbContext _context;
    public TeachersRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<TeacherEntity> GetById(Guid id)
    {
        return await _context.Theachers
            .AsNoTracking()
            .FirstAsync(s => s.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<List<TeacherEntity>> GetAll()
    {
        return await _context.Theachers
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }
}