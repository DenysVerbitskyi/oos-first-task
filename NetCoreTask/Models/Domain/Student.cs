using System.ComponentModel.DataAnnotations;

namespace NetCoreTask.Models.Domain;

public class Student
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(60, MinimumLength = 1)]
    [RegularExpression(@"^(?i)[A-Za-z]([-][A-Za-z])?[A-Za-z]*$", ErrorMessage = "First name contains invalid characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(60, MinimumLength = 1)]
    [RegularExpression(@"^(?i)[A-Za-z]([-][A-Za-z])?[A-Za-z]*$", ErrorMessage = "Last name contains invalid characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
