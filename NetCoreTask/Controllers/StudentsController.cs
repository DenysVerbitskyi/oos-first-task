using Microsoft.AspNetCore.Mvc;
using NetCoreTask.Models;
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
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            return await _service.GetAll();
        }

        /// <summary>
        /// Get student by id.
        /// </summary>
        /// <param name="id">The student's id.</param>
        /// <returns>The <see cref="StudentDto"/> that was found or null.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(Guid id)
        {
            var student = await _service.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        /// <summary>
        /// Update student's information in the database.
        /// </summary>
        /// <param name="student">Student entity to update.</param>
        /// <param name="id">Student's Id.</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(Guid id, StudentDto student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _service.Update(student);
            return NoContent();
        }

        /// <summary>
        /// Method for creating a new student.
        /// </summary>
        /// <param name="student">Student entity to add.</param>
        /// <returns>The student that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto student)
        {
            await _service.Add(student);

            return CreatedAtAction("Get", new { id = student.Id }, student);
        }

        /// <summary>
        /// Delete the student from the database.
        /// </summary>
        /// <param name="id">The student's id.</param>
        /// <returns>If deletion was successful, the result will be Status Code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> Delete(Guid id)
        {
            var student = await _service.Delete(id);
            if (student == null)
            {
                return NotFound(student);
            }
            return Ok(student);
        }
    }
}
