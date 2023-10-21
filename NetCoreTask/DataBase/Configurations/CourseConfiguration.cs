using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetCoreTask.DataBase.Entities;

namespace NetCoreTask.DataBase.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Teacher)
            .WithMany(c => c.Courses)
            .HasForeignKey(e => e.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Students)
            .WithMany(c => c.Courses);

    }
}