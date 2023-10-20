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
                Id = 1,
                FirstName = "Ivan",
                LastName = "Petrenko",
                DateOfBirth = new DateTime(1991, 01, 01)
            },
            new StudentEntity
            {
                Id = 2,
                FirstName = "Oles",
                LastName = "Kurko",
                DateOfBirth = new DateTime(1992, 02, 02)
            },
            new StudentEntity
            {
                Id = 3,
                FirstName = "Pavlo",
                LastName = "Skoropadskiy",
                DateOfBirth = new DateTime(1993, 03, 03)
            },
            new StudentEntity
            {
                Id = 4,
                FirstName = "Bohdan",
                LastName = "Khmelnitskiy",
                DateOfBirth = new DateTime(1994, 04, 04)
            },
            new StudentEntity
            {
                Id = 5,
                FirstName = "Ivan",
                LastName = "Bohun",
                DateOfBirth = new DateTime(1995, 05, 05)
            });

        builder.Entity<TeacherEntity>().HasData(
            new TeacherEntity
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Oslova",
                Email = "1@gmail.com"
            },
            new TeacherEntity
            {
                Id = 2,
                FirstName = "Olha",
                LastName = "Chorna",
                Email = "2@gmail.com"
            },
            new TeacherEntity
            {
                Id = 3,
                FirstName = "Danylo",
                LastName = "Honcharenko",
                Email = "3@gmail.com"
            },
            new TeacherEntity
            {
                Id = 4,
                FirstName = "Alex",
                LastName = "Doe",
                Email = "4@gmail.com"
            },
            new TeacherEntity
            {
                Id = 5,
                FirstName = "John",
                LastName = "Tarasenko",
                Email = "5@gmail.com"
            });

        builder.Entity<CourseEntity>().HasData(
           new CourseEntity
           {
               Id = 1,
               CourseName = "OOP",
               Description = "Object-Oriented Programming",
               TeacherId = 1
           },
           new CourseEntity
           {
               Id = 2,
               CourseName = "Patterns",
               Description = "design patterns",
               TeacherId = 2
           },
           new CourseEntity
           {
               Id = 3,
               CourseName = "Entity",
               Description = "Entity Framework",
               TeacherId = 3
           },
           new CourseEntity
           {
               Id = 4,
               CourseName = "Data types",
               Description = "Value and reference types",
               TeacherId = 4
           },
           new CourseEntity
           {
               Id = 5,
               CourseName = "GC",
               Description = "Garbage collector",
               TeacherId = 5
           });

        builder.Entity<StudentCoursesEntity>().HasData(
           new StudentCoursesEntity
           {
               Id = 1,
               CourseId = 1,
               StudentId = 1
           },
           new StudentCoursesEntity
           {
               Id = 2,
               CourseId = 1,
               StudentId = 2
           },
           new StudentCoursesEntity
           {
               Id = 3,
               CourseId = 1,
               StudentId = 3
           },
           new StudentCoursesEntity
           {
               Id = 4,
               CourseId = 2,
               StudentId = 1
           },
           new StudentCoursesEntity
           {
               Id = 5,
               CourseId = 2,
               StudentId = 3
           },
           new StudentCoursesEntity
           {
               Id = 6,
               CourseId = 2,
               StudentId = 4
           },
           new StudentCoursesEntity
           {
               Id = 7,
               CourseId = 1,
               StudentId = 2
           },
           new StudentCoursesEntity
           {
               Id = 8,
               CourseId = 3,
               StudentId = 4
           },
           new StudentCoursesEntity
           {
               Id = 9,
               CourseId = 3,
               StudentId = 5
           },
           new StudentCoursesEntity
           {
               Id = 10,
               CourseId = 4,
               StudentId = 2
           },
           new StudentCoursesEntity
           {
               Id = 11,
               CourseId = 4,
               StudentId = 5
           },
           new StudentCoursesEntity
           {
               Id = 12,
               CourseId = 4,
               StudentId = 1
           },
           new StudentCoursesEntity
           {
               Id = 13,
               CourseId = 5,
               StudentId = 2
           },
           new StudentCoursesEntity
           {
               Id = 14,
               CourseId = 5,
               StudentId = 5
           },
           new StudentCoursesEntity
           {
               Id = 15,
               CourseId = 5,
               StudentId = 3
           },
           new StudentCoursesEntity
           {
               Id = 16,
               CourseId = 5,
               StudentId = 1
           });
    }
    }
