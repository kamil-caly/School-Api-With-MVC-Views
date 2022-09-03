using Microsoft.AspNetCore.Mvc;
using SchoolTask.Entities;
using SchoolTask.Services;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Controllers
{
    [ApiController]
    [Route("api/school")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService service;

        public SchoolController(ISchoolService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<School>> Get()
        {
            var schools = service.GetAll();

            if (schools is null)
            {
                return NotFound();
            }

            return Ok(schools);
        }

        [HttpGet("{id}")]
        public ActionResult<SchoolDto> Get([FromRoute] int id)
        {
            var school = service.GetById(id);
            
            if(school is null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateSchoolDto dto)
        {

            var schoolId = service.CreateSchool(dto);

            return Created($"/api/school/{schoolId}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateSchoolDto dto)
        {
            var isUpdated = service.UpdateSchool(dto, id);

            return isUpdated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            service.DeleteSchool(id);

            return Ok();
        }
    }
}
