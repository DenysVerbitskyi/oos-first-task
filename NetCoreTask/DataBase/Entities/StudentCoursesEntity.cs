using System.ComponentModel.DataAnnotations;

namespace NetCoreTask.DataBase.Entities;

public class StudentCoursesEntity
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public StudentEntity Student { get; set; }
    public virtual CourseEntity Course { get; set; }
}
