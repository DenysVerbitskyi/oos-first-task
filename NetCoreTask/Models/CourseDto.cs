using NetCoreTask.DataBase.Entities;
using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models;

public class CourseDto : IDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CourseName { get; set; }
    public string Description { get; set; }
    public Guid TeacherId { get; set; }
}
