using Mapster;

using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models;

namespace NetCoreTask.DataBase.Repository.Services;

public class TeachersRepository : RepositoryBase<TeacherEntity, UniversityDbContext>
{
    private readonly UniversityDbContext _context;
    public TeachersRepository(UniversityDbContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<TeacherEntity> GetById(int id)
    {
        var teacher = await _context.Theachers
            .AsNoTracking()
            .FirstAsync(s => s.Id == id)
            .ConfigureAwait(false);
        
        return teacher;
    }

    public override async Task<List<TeacherEntity>> GetAll()
    {
        var teachers = await _context.Theachers
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);

        return teachers;
    }
}