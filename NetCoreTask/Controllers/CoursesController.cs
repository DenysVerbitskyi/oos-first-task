using Microsoft.AspNetCore.Mvc;

using NetCoreTask.Models;
using NetCoreTask.Services.Abstractions;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IApiService<CourseDto> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// </summary>
        /// <param name="service">Service for entity CRUD operations.</param>
        public CoursesController(IApiService<CourseDto> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all courses from the database.
        /// </summary>
        /// <returns>The result is a <see cref="IEnumerable{CourseDto}"/> a list of courses that were received.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            return await _service.GetAll();
        }

        /// <summary>
        /// Get course by id.
        /// </summary>
        /// <param name="id">The course's id.</param>
        /// <returns>The <see cref="CourseDto"/> that was found or null.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(Guid id)
        {
            var course = await _service.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        /// <summary>
        /// Update course's information in the database.
        /// </summary>
        /// <param name="course">Course entity to update.</param>
        /// <param name="id">Course's Id.</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(Guid id, CourseDto course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            await _service.Update(course);
            return NoContent();
        }

        /// <summary>
        /// Method for creating a new course.
        /// </summary>
        /// <param name="course">Course entity to add.</param>
        /// <returns>The course that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(CourseDto course)
        {
            await _service.Add(course);

            return CreatedAtAction("GetCourseById", new { id = course.Id }, course);
        }

        /// <summary>
        /// Delete the course from the database.
        /// </summary>
        /// <param name="id">The course's id.</param>
        /// <returns>If deletion was successful, the result will be Status Code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseDto>> Delete(Guid id)
        {
            var course = await _service.Delete(id);
            if (course == null)
            {
                return NotFound(course);
            }
            return Ok(course);
        }
    }
}
