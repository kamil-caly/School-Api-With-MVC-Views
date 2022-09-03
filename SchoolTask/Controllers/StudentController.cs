using Microsoft.AspNetCore.Mvc;
using SchoolTask.Interfaces;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Controllers
{
    [ApiController]
    [Route("/api/school/{schoolId}/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudetnService studentService;

        public StudentController(IStudetnService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> Get([FromRoute] int schoolId, [FromQuery] string Name)
        {
            var students = studentService.GetAll(schoolId, Name);

            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public ActionResult<StudentDto> Get([FromRoute] int schoolId, [FromRoute] int studentId)
        {
            var student = studentService.GetById(schoolId, studentId);

            return Ok(student);
        }

        [HttpPost]
        public ActionResult Create([FromRoute] int schoolId, [FromBody] CreateStudentDto dto)
        {
            var studentId = studentService.Create(schoolId, dto);

            return Created($"/api/school/{schoolId}/student/{studentId}", null);
        }

        [HttpPut("{studentId}")]
        public ActionResult Update([FromRoute] int schoolId, [FromRoute] int studentId,
            [FromBody] UpdateStudentDto dto)
        {
            studentService.Update(schoolId, studentId, dto);

            return Ok("Student updated");
        }

        [HttpDelete("{studentId}")]
        public ActionResult Delete([FromRoute] int schoolId, [FromRoute] int studentId)
        {
            studentService.Delete(schoolId, studentId);

            return NoContent()
        }
    }
}
