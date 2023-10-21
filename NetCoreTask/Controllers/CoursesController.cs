using Mapster;

using Microsoft.AspNetCore.Mvc;

using NetCoreTask.Models.Domain;
using NetCoreTask.Models.Dto;
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
        /// <returns>The result is a <see cref="IEnumerable{Course}"/> a list of courses that were received.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var coursesDto = await _service.GetAll();

            return coursesDto.Adapt<List<Course>>();
        }

        /// <summary>
        /// Get course by id.
        /// </summary>
        /// <param name="id">The course's id.</param>
        /// <returns>The <see cref="Course"/> that was found or null.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(Guid id)
        {
            var course = await _service.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course.Adapt<Course>());
        }

        /// <summary>
        /// Update course's information in the database.
        /// </summary>
        /// <param name="course">Course entity to update.</param>
        /// <param name="id">Course's Id.</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(Guid id, Course course)
        {
            var courseDto = course.Adapt<CourseDto>();
            courseDto.Id = id;

            await _service.Update(courseDto);

            return NoContent();
        }

        /// <summary>
        /// Method for creating a new course.
        /// </summary>
        /// <param name="course">Course entity to add.</param>
        /// <returns>The course that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            var courseDto = course.Adapt<CourseDto>();

            await _service.Add(courseDto);

            return CreatedAtAction("GetCourseById", new { id = courseDto.Id }, courseDto);
        }

        /// <summary>
        /// Delete the course from the database.
        /// </summary>
        /// <param name="id">The course's id.</param>
        /// <returns>If deletion was successful, the result will be Status Code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> Delete(Guid id)
        {
            var course = await _service.Delete(id);
            if (course == null)
            {
                return NotFound(course);
            }
            return Ok(course.Adapt<Course>());
        }
    }
}
