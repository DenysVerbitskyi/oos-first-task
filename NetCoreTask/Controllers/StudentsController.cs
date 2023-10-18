using Microsoft.AspNetCore.Mvc;

using NetCoreTask.DataBase.Abstraction;
using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;

namespace NetCoreTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEntity>>> GetStudents()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudentById(int id)
        {
            var student = await _repository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, StudentEntity student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _repository.Update(student);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StudentEntity>> CreateStudent(StudentEntity student)
        {
            await _repository.Add(student);

            return CreatedAtAction("Get", new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentEntity>> Delete(int id)
        {
            var student = await _repository.Delete(id);
            if (student == null)
            {
                return NotFound(student);
            }
            return Ok(student);
        }
    }
}
