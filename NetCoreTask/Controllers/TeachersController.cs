using Microsoft.AspNetCore.Mvc;
using NetCoreTask.Models;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IApiService<TeacherDto> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeachersController"/> class.
        /// </summary>
        /// <param name="service">Service for entity CRUD operations.</param>
        public TeachersController(IApiService<TeacherDto> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all teachers from the database.
        /// </summary>
        /// <returns>The result is a <see cref="IEnumerable{TeacherDto}"/> a list of teachers that were received.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers()
        {
            return await _service.GetAll();
        }

        /// <summary>
        /// Get teacher by id.
        /// </summary>
        /// <param name="id">The teacher's id.</param>
        /// <returns>The <see cref="TheacerDto"/> that was found or null.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetTeacherById(Guid id)
        {
            var teacher = await _service.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        /// <summary>
        /// Update teacher's information in the database.
        /// </summary>
        /// <param name="teacher">Teacher entity to update.</param>
        /// <param name="id">Teacher's Id.</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacher(Guid id, TeacherDto teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            await _service.Update(teacher);
            return NoContent();
        }

        /// <summary>
        /// Method for creating a new teacher.
        /// </summary>
        /// <param name="teacher">Teacher entity to add.</param>
        /// <returns>The teacher that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> CreateTeacher(TeacherDto teacher)
        {
            await _service.Add(teacher);

            return CreatedAtAction("Get", new { id = teacher.Id }, teacher);
        }

        /// <summary>
        /// Delete the teacher from the database.
        /// </summary>
        /// <param name="id">The teacher's id.</param>
        /// <returns>If deletion was successful, the result will be Status Code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var teacher = await _service.Delete(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
