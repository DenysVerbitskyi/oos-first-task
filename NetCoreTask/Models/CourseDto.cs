using NetCoreTask.DataBase.Entities;
using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models;

public class CourseDto : IDto
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int TeacherId { get; set; }
}
