using Microsoft.AspNetCore.Mvc;
using SchoolTask.Entities;
using SchoolTask.Services;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Controllers
{
    [ApiController]
    [Route("/api/school/{schoolId}/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudetnService service;

        public StudentController(IStudetnService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> Get([FromRoute] int schoolId, [FromQuery] string Name)
        {
            var students = service.GetAll(schoolId, Name);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int schoolId, [FromBody] CreateStudentDto dto)
        {
            var studentId = service.Create(schoolId, dto);

            return Created($"/api/school/{schoolId}/student/{studentId}", null);
        }

    }
}
