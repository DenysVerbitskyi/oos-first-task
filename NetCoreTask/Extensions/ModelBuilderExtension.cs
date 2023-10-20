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

        builder.Entity<StudentCoursesEntity>().HasData(
           new StudentCoursesEntity
           {
               Id = new Guid("891645b4-8721-4663-8c0f-fdf77d0ba5b6"),
               CourseId = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
               StudentId = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("efda91b1-37ee-46d0-aa21-d3306e8e43e8"),
               CourseId = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
               StudentId = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("37cc8399-6eab-42cb-a940-d5b7188cff8a"),
               CourseId = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
               StudentId = new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("1de0714c-cd6c-42be-a2db-1918e7ccde36"),
               CourseId = new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"),
               StudentId = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("59710adc-59d5-42e4-a32b-47a381bf19aa"),
               CourseId = new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"),
               StudentId = new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("bc78ab42-c09c-41dc-94df-663ea245cf1c"),
               CourseId = new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"),
               StudentId = new Guid("f55eb974-f8fd-4070-b1f2-e7fbb2a90be1")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("3edad7c7-c959-48fb-b919-7f1f15d1b14a"),
               CourseId = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
               StudentId = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("14b74831-32b5-467c-9dfc-db512b798170"),
               CourseId = new Guid("79e38fe3-04b6-4dfb-905b-453a26f9338c"),
               StudentId = new Guid("f55eb974-f8fd-4070-b1f2-e7fbb2a90be1")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("1a49d1ad-4d63-4b88-a94d-e2324ae212bc"),
               CourseId = new Guid("79e38fe3-04b6-4dfb-905b-453a26f9338c"),
               StudentId = new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("681797e7-57ef-4d93-adc6-6de07c0cd98c"),
               CourseId = new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"),
               StudentId = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("3317dab6-2fc9-4408-818b-3085b548ee7f"),
               CourseId = new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"),
               StudentId = new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("1283f2ad-44d8-4edd-b2ce-075eb2ca0558"),
               CourseId = new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"),
               StudentId = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("a7bec75e-2d76-4b5e-81c5-8f272a95884a"),
               CourseId = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
               StudentId = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("367daca2-10cc-47d6-882b-d1db86f43b0a"),
               CourseId = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
               StudentId = new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("e7885e28-0d62-415b-9505-925c4b2974f0"),
               CourseId = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
               StudentId = new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e")
           },
           new StudentCoursesEntity
           {
               Id = new Guid("5cf69803-ae98-49c6-a4ac-27c637804c3d"),
               CourseId = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
               StudentId = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa")
           });
    }
}
