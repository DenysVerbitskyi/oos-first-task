using System.ComponentModel.DataAnnotations;

using NetCoreTask.DataBase.Abstraction;

namespace NetCoreTask.DataBase.Entities;

public class StudentCoursesEntity : IEntity
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public StudentEntity Student { get; set; }
    public virtual CourseEntity Course { get; set; }

    internal IEnumerable<object> Select(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}
