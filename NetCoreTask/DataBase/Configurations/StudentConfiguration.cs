using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreTask.DataBase.Entities;

namespace NetCoreTask.DataBase.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.HasMany(c => c.Courses)
            .WithMany(c => c.Students);
    }
}