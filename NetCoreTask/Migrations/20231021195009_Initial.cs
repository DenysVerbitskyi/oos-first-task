using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetCoreTask.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseEntityStudentEntity",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEntityStudentEntity", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseEntityStudentEntity_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEntityStudentEntity_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("81722d70-0aa4-4215-b4ab-924388c49e1c"), new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oles", "Kurko" },
                    { new Guid("ae9d78c6-640b-45fb-9526-0d8ac676cd23"), new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Bohun" },
                    { new Guid("c3673509-7174-40c3-925c-fe8dfde516aa"), new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Petrenko" },
                    { new Guid("deca9323-cc0e-47cc-b80a-a83add90f80e"), new DateTime(1993, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pavlo", "Skoropadskiy" },
                    { new Guid("f55eb974-f8fd-4070-b1f2-e7fbb2a90be1"), new DateTime(1994, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohdan", "Khmelnitskiy" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7"), "1@gmail.com", "Maria", "Oslova" },
                    { new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb"), "5@gmail.com", "John", "Tarasenko" },
                    { new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae"), "4@gmail.com", "Alex", "Doe" },
                    { new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314"), "3@gmail.com", "Danylo", "Honcharenko" },
                    { new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5"), "2@gmail.com", "Olha", "Chorna" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Description", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("79e38fe3-04b6-4dfb-905b-453a26f9338c"), "Entity", "Entity Framework", new Guid("a15b1f24-bfb1-4ef9-8cd4-6b3dd3079314") },
                    { new Guid("8790dc4a-31e4-4128-92f3-1bea4b1aa723"), "GC", "Garbage collector", new Guid("346823eb-c691-43d7-a373-25af9b5e6dfb") },
                    { new Guid("8e5ac024-9228-494e-aab9-f12c96506fbb"), "Data types", "Value and reference types", new Guid("67f6b408-a4bd-454a-8719-5cb194ba91ae") },
                    { new Guid("faf254ab-b4cb-492d-9117-b62efb7e0973"), "Patterns", "design patterns", new Guid("df04f00f-8efa-40e3-b514-08d5ba2fe0f5") },
                    { new Guid("ff7aa895-2c34-4dc2-91ca-0e7107c3f636"), "OOP", "Object-Oriented Programming", new Guid("1187d317-3a38-42f7-ab03-f33a61a8d9e7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEntityStudentEntity_StudentsId",
                table: "CourseEntityStudentEntity",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEntityStudentEntity");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
