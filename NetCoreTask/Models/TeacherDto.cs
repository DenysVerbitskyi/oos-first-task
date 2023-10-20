using NetCoreTask.Models.Abstractions;

namespace NetCoreTask.Models;

public class TeacherDto : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
