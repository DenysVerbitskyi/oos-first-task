using System.ComponentModel.DataAnnotations.Schema;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class StudentCoursesEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }

    public StudentEntity Student { get; set; }
    public virtual CourseEntity Course { get; set; }

    internal IEnumerable<object> Select(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}
