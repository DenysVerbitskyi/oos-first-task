using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models.Domain;

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
        return await _context.Students
            .AsNoTracking()
            .FirstAsync(s => s.Id == id)
            .ConfigureAwait(false);
    }

    public override async Task<List<StudentEntity>> GetAll()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }
}
