using Microsoft.AspNetCore.Mvc;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseEntity>>> GetCourses()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseEntity>> GetCourseById(int id)
        {
            var course = await _repository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(int id, CourseEntity course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            await _repository.Update(course);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CourseEntity>> CreateStudent(CourseEntity course)
        {
            await _repository.Add(course);

            return CreatedAtAction("Get", new { id = course.Id }, course);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseEntity>> Delete(int id)
        {
            var course = await _repository.Delete(id);
            if (course == null)
            {
                return NotFound(course);
            }
            return Ok(course);
        }
    }
}
