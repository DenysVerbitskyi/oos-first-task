using System.ComponentModel.DataAnnotations;

using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models.Dto;

public class StudentDto : IDto
{
    public Guid Id { get; set; } = default;

    [Required(ErrorMessage = "First name is required")]
    [StringLength(60, MinimumLength = 1)]
    [RegularExpression(@"^(?i)[A-Za-z]([-][A-Za-z])?[A-Za-z]*$", ErrorMessage = "First name contains invalid characters")]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
