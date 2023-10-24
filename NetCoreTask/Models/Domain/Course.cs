using System.ComponentModel.DataAnnotations;

namespace NetCoreTask.Models.Domain;

public class Course
{
    [Required(ErrorMessage = "Course name is required")]
    [DataType(DataType.Text)]
    [MaxLength(120)]
    [MinLength(2, ErrorMessage = "Course Name must be a minimum length of '2'.")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [MaxLength(60)]
    [MinLength(1)]
    public string Description { get; set; }

    [Required(ErrorMessage = "The TeacherId field is required.")]
    public Guid TeacherId { get; set; }
}
