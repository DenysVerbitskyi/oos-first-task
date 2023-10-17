using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.Extensions;

namespace NetCoreTask.DataBase;

public class UniveristyDbContext : DbContext
{
    public UniveristyDbContext(DbContextOptions<UniveristyDbContext> options)
        : base(options)
    {
    }

    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<TeacherEntity> Theachers { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<StudentCoursesEntity> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        builder.Seed();
    }
}