using Microsoft.EntityFrameworkCore;

using NetCoreTask.DataBase.Entities;

namespace NetCoreTask.Extensions;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.Entity<StudentEntity>().HasData(
            new StudentEntity
            {
                Id = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa"),
                FirstName = "Ivan",
                LastName = "Petrenko",
                DateOfBirth = new DateTime(1991, 01, 01)
            },
            new StudentEntity
            {
                Id = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c"),
                FirstName = "Oles",
                LastName = "Kurko",
                DateOfBirth = new DateTime(1992, 02, 02)
            },
            new StudentEntity
            {
                Id = new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e"),
                FirstName = "Pavlo",
                LastName = "Skoropadskiy",
                DateOfBirth = new DateTime(1993, 03, 03)
            },
            new StudentEntity
            {
                Id = new Guid("f55eb974-f8fd-4070-b1f2-e7fbb2a90be1"),
                FirstName = "Bohdan",
                LastName = "Khmelnitskiy",
                DateOfBirth = new DateTime(1994, 04, 04)
            },
            new StudentEntity
            {
                Id = new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23"),
                FirstName = "Ivan",
                LastName = "Bohun",
                DateOfBirth = new DateTime(1995, 05, 05)
            });

        builder.Entity<TeacherEntity>().HasData(
            new TeacherEntity
            {
                Id = new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7"),
                FirstName = "Maria",
                LastName = "Oslova",
                Email = "1@gmail.com"
            },
            new TeacherEntity
            {
                Id = new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5"),
                FirstName = "Olha",
                LastName = "Chorna",
                Email = "2@gmail.com"
            },
            new TeacherEntity
            {
                Id = new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314"),
                FirstName = "Danylo",
                LastName = "Honcharenko",
                Email = "3@gmail.com"
            },
            new TeacherEntity
            {
                Id = new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae"),
                FirstName = "Alex",
                LastName = "Doe",
                Email = "4@gmail.com"
            },
            new TeacherEntity
            {
                Id = new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb"),
                FirstName = "John",
                LastName = "Tarasenko",
                Email = "5@gmail.com"
            });

        builder.Entity<CourseEntity>().HasData(
           new CourseEntity
           {
               Id = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
               CourseName = "OOP",
               Description = "Object-Oriented Programming",
               TeacherId = new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7")
           },
           new CourseEntity
           {
               Id = new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"),
               CourseName = "Patterns",
               Description = "design patterns",
               TeacherId = new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5")
           },
           new CourseEntity
           {
               Id = new Guid("79e38fe3-04b6-4dfb-905b-453a26f9338c"),
               CourseName = "Entity",
               Description = "Entity Framework",
               TeacherId = new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314")
           },
           new CourseEntity
           {
               Id = new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"),
               CourseName = "Data types",
               Description = "Value and reference types",
               TeacherId = new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae")
           },
           new CourseEntity
           {
               Id = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
               CourseName = "GC",
               Description = "Garbage collector",
               TeacherId = new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb")
           });
    }
}
