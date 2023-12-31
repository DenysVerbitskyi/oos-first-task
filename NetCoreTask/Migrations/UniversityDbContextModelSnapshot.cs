﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreTask.DataBase;

#nullable disable

namespace NetCoreTask.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    partial class UniversityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseEntityStudentEntity", b =>
                {
                    b.Property<Guid>("CoursesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("char(36)");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseEntityStudentEntity");
                });

            modelBuilder.Entity("NetCoreTask.DataBase.Entities.CourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"),
                            CourseName = "OOP",
                            Description = "Object-Oriented Programming",
                            TeacherId = new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7")
                        },
                        new
                        {
                            Id = new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"),
                            CourseName = "Patterns",
                            Description = "design patterns",
                            TeacherId = new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5")
                        },
                        new
                        {
                            Id = new Guid("79e38fe3-04b6-4dfb-905b-453a26f9338c"),
                            CourseName = "Entity",
                            Description = "Entity Framework",
                            TeacherId = new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314")
                        },
                        new
                        {
                            Id = new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"),
                            CourseName = "Data types",
                            Description = "Value and reference types",
                            TeacherId = new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae")
                        },
                        new
                        {
                            Id = new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"),
                            CourseName = "GC",
                            Description = "Garbage collector",
                            TeacherId = new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb")
                        });
                });

            modelBuilder.Entity("NetCoreTask.DataBase.Entities.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3673509-7174-40c3-925c-fe8dfde516aa"),
                            DateOfBirth = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ivan",
                            LastName = "Petrenko"
                        },
                        new
                        {
                            Id = new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c"),
                            DateOfBirth = new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Oles",
                            LastName = "Kurko"
                        },
                        new
                        {
                            Id = new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e"),
                            DateOfBirth = new DateTime(1993, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Pavlo",
                            LastName = "Skoropadskiy"
                        },
                        new
                        {
                            Id = new Guid("f55eb974-f8fd-4070-b1f2-e7fbb2a90be1"),
                            DateOfBirth = new DateTime(1994, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bohdan",
                            LastName = "Khmelnitskiy"
                        },
                        new
                        {
                            Id = new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23"),
                            DateOfBirth = new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ivan",
                            LastName = "Bohun"
                        });
                });

            modelBuilder.Entity("NetCoreTask.DataBase.Entities.TeacherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7"),
                            Email = "1@gmail.com",
                            FirstName = "Maria",
                            LastName = "Oslova"
                        },
                        new
                        {
                            Id = new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5"),
                            Email = "2@gmail.com",
                            FirstName = "Olha",
                            LastName = "Chorna"
                        },
                        new
                        {
                            Id = new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314"),
                            Email = "3@gmail.com",
                            FirstName = "Danylo",
                            LastName = "Honcharenko"
                        },
                        new
                        {
                            Id = new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae"),
                            Email = "4@gmail.com",
                            FirstName = "Alex",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb"),
                            Email = "5@gmail.com",
                            FirstName = "John",
                            LastName = "Tarasenko"
                        });
                });

            modelBuilder.Entity("CourseEntityStudentEntity", b =>
                {
                    b.HasOne("NetCoreTask.DataBase.Entities.CourseEntity", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCoreTask.DataBase.Entities.StudentEntity", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetCoreTask.DataBase.Entities.CourseEntity", b =>
                {
                    b.HasOne("NetCoreTask.DataBase.Entities.TeacherEntity", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("NetCoreTask.DataBase.Entities.TeacherEntity", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
