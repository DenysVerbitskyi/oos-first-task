using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreTask.DataBase.Entities;

public class StudentEntity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTimeOffset DateOfBirth { get; set; }

    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
