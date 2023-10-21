using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class TeacherEntity : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public virtual ICollection<CourseEntity> Courses { get; set; }
}
