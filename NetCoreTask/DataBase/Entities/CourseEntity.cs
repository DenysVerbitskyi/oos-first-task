using System.ComponentModel.DataAnnotations;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class CourseEntity : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Course name is required")]
    [MaxLength(50)]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "Course description is required")]
    [MaxLength(300, ErrorMessage = "Course description maximum length must be 300 symbols")]
    public string Description { get; set; }

    [Required]
    public int TeacherId { get; set; }

    public virtual TeacherEntity Teacher { get; set; }
    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
