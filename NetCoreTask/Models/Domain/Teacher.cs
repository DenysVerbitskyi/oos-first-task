using System.ComponentModel.DataAnnotations;

namespace NetCoreTask.Models.Domain;

public class Teacher
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(60, MinimumLength = 1)]
    [RegularExpression(@"^(?i)[A-Za-z]([-][A-Za-z])?[A-Za-z]*$", ErrorMessage = "First name contains invalid characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(60, MinimumLength = 1)]
    [RegularExpression(@"^(?i)[A-Za-z]([-][A-Za-z])?[A-Za-z]*$", ErrorMessage = "Last name contains invalid characters")]
    public string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(256)]
    public string Email { get; set; }
}
