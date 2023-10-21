using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class StudentEntity : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
