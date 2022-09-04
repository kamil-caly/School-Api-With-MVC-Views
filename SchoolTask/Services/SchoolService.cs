using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Entities;
using SchoolTask.Exceptions;
using SchoolTask.Interfaces;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Services
{
    
    public class SchoolService : ISchoolService
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public SchoolService(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<SchoolDto> GetAll()
        {
            var schools = dbContext
                .Schools
                .Include(s => s.Students)
                .ToList();

            if (!schools.Any())
            {
                throw new NotFoundException("Cannot found any school");
            }

            var schoolDtos = mapper.Map<List<SchoolDto>>(schools);
            return schoolDtos;
        }

        public SchoolDto GetById(int id)
        {
            var school = this.GetSchool(id);

            var schoolDto = mapper.Map<SchoolDto>(school);
            return schoolDto;
        }

        public int CreateSchool(CreateSchoolDto dto)
        {
            var school = mapper.Map<School>(dto);
            dbContext.Schools.Add(school);
            dbContext.SaveChanges();

            return school.Id;
        }

        public void UpdateSchool(UpdateSchoolDto dto, int id)
        {
            var school = this.GetSchool(id);

            school.Street = dto.Street;
            school.City = dto.City;
            school.FullName = dto.FullName;

            dbContext.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var school = this.GetSchool(id);

            dbContext.Schools.Remove(school);
            dbContext.SaveChanges();
        }

        public School GetSchool(int id)
        {
            var school = dbContext
                .Schools
                .Include(s => s.Students)
                .FirstOrDefault(s => s.Id == id);

            if (school is null)
            {
                throw new NotFoundException("School not found");
            }

            return school;
        }
    }
}
