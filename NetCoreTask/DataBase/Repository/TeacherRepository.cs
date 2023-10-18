using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.DataBase.Repository;

public class TeacherRepository : RepositoryBase<TeacherEntity, UniversityDbContext>, ITeacherRepository
{
    private readonly UniversityDbContext _context;
    public TeacherRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<TeacherEntity> GetById(int id)
    {
        return await _context.Theachers
            .AsNoTracking()
            .FirstAsync(s => s.Id == id);
    }

    public override async Task<List<TeacherEntity>> GetAll()
    {
        return await _context.Theachers
            .AsNoTracking()
            .ToListAsync();
    }
}