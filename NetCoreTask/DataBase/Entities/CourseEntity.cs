using System.ComponentModel.DataAnnotations;

namespace NetCoreTask.DataBase.Entities;

public class CourseEntity
{
    [Key]
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int TeacherId { get; set; }

    public virtual TeacherEntity Teacher { get; set; }
    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
