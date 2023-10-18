using Microsoft.AspNetCore.Mvc;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeachersController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherEntity>>> GetTeachers()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherEntity>> GetTeacherById(int id)
        {
            var teacher = await _repository.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacher(int id, TeacherEntity teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            await _repository.Update(teacher);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TeacherEntity>> CreateTeacher(TeacherEntity teacher)
        {
            await _repository.Add(teacher);

            return CreatedAtAction("Get", new { id = teacher.Id }, teacher);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TeacherEntity>> Delete(int id)
        {
            var teacher = await _repository.Delete(id);
            if (teacher == null)
            {
                return NotFound(teacher);
            }
            return Ok(teacher);
        }
    }
}
