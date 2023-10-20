using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class CourseEntity : IEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(50)]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "Course description is required")]
    [MaxLength(300, ErrorMessage = "Course description maximum length must be 300 symbols")]
    public string Description { get; set; }

    public Guid TeacherId { get; set; }

    public virtual TeacherEntity Teacher { get; set; }
    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
