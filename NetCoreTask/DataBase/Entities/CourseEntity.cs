using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class CourseEntity : IEntity
{
    public Guid Id { get; set; }

    public string CourseName { get; set; }

    public string Description { get; set; }

    public Guid TeacherId { get; set; }

    public virtual TeacherEntity Teacher { get; set; }
    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
