//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using NetCoreTask.DataBase.Entities;

//namespace NetCoreTask.DataBase.Configurations;

//public class StudentCoursesConfiguration : IEntityTypeConfiguration<StudentCoursesEntity>
//{
//    public void Configure(EntityTypeBuilder<StudentCoursesEntity> builder)
//    {
//        builder.ToTable("StudentCourses");

//        builder.HasKey(e => e.Id);

//        builder.HasOne(e => e.Student)
//            .WithMany(e => e.StudentCourses)
//            .HasForeignKey(e => e.StudentId)
//            .OnDelete(DeleteBehavior.Cascade);

//        builder.HasOne(e => e.Course)
//            .WithMany(e => e.StudentCourses)
//            .HasForeignKey(e => e.CourseId)
//            .OnDelete(DeleteBehavior.Cascade);
//    }
//}