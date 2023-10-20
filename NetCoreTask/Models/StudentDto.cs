using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models;

public class StudentDto : IDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
