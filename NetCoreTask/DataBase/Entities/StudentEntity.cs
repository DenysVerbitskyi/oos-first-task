using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class StudentEntity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
