using System.ComponentModel.DataAnnotations;

using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models.Dto;

public class StudentDto : IDto
{
    public Guid Id { get; set; } = default;

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
