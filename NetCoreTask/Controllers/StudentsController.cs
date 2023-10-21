using Mapster;

using Microsoft.AspNetCore.Mvc;

using NetCoreTask.Models.Domain;
using NetCoreTask.Models.Dto;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IApiService<StudentDto> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsController"/> class.
        /// </summary>
        /// <param name="service">Service for entity CRUD operations.</param>
        public StudentsController(IApiService<StudentDto> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all students from the database.
        /// </summary>
        /// <returns>The result is a <see cref="IEnumerable{StudentDto}"/> a list of students that were received.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var studentsDto = await _service.GetAll();

            return studentsDto.Adapt<List<Student>>();
        }

        /// <summary>
        /// Get student by id.
        /// </summary>
        /// <param name="id">The student's id.</param>
        /// <returns>The <see cref="StudentDto"/> that was found or null.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(Guid id)
        {
            var student = await _service.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student.Adapt<Student>());
        }

        /// <summary>
        /// Update student's information in the database.
        /// </summary>
        /// <param name="student">Student entity to update.</param>
        /// <param name="id">Student's Id.</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(Guid id, Student student)
        {
            var studentDto = student.Adapt<StudentDto>();
            studentDto.Id = id;

            await _service.Update(studentDto);
            return NoContent();
        }

        /// <summary>
        /// Method for creating a new student.
        /// </summary>
        /// <param name="student">Student entity to add.</param>
        /// <returns>The student that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            var studentDto = student.Adapt<StudentDto>();

            await _service.Add(studentDto);

            return CreatedAtAction("GetStudentById", new { id = studentDto.Id }, student);
        }

        /// <summary>
        /// Delete the student from the database.
        /// </summary>
        /// <param name="id">The student's id.</param>
        /// <returns>If deletion was successful, the result will be Status Code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(Guid id)
        {
            var student = await _service.Delete(id);
            if (student == null)
            {
                return NotFound(student);
            }
            return Ok(student.Adapt<Student>());
        }
    }
}
