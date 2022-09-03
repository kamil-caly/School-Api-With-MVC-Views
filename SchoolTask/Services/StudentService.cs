using AutoMapper;
using SchoolTask.Entities;
using SchoolTask.Exceptions;
using SchoolTask.Interfaces;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Services
{
    
    public class StudentService : IStudetnService
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ISchoolService schoolService;

        public StudentService(SchoolDbContext dbContext, IMapper mapper,
            ISchoolService schoolService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.schoolService = schoolService;
        }

        public List<StudentDto> GetAll(int schoolId, string name)
        {
            var school = schoolService.GetSchool(schoolId);

            var students = dbContext
                .Students
                .Where(x => x.SchoolId == schoolId 
                 && (name == null 
                 || x.Name.ToLower().Contains(name.ToLower())))
                .ToList();

            var studentsDto = mapper.Map<List<StudentDto>>(students);
            return studentsDto;
        }

        public int Create(int schoolId, CreateStudentDto dto)
        {
            var school = schoolService.GetSchool(schoolId);

            var studentEntity = mapper.Map<Student>(dto);

            studentEntity.SchoolId = schoolId;

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return studentEntity.Id;
        }

        public StudentDto GetById(int schoolId, int studentId)
        {
            var student = this.GetStudent(studentId, schoolId);

            var studetDto = mapper.Map<StudentDto>(student);
            return studetDto;
        }

        public void Update(int schoolId, int studentId, UpdateStudentDto dto)
        {
            var student = this.GetStudent(studentId, schoolId);

            student.Name = dto.Name;
            student.Surname = dto.Surname;
            student.StudentIndex = dto.StudentIndex;

            dbContext.SaveChanges();
        }

        public void Delete(int schoolId, int studentId)
        {
            var student = this.GetStudent(studentId, schoolId);

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
        private Student GetStudent(int studnetId, int schoolId)
        {
            var school = schoolService.GetSchool(schoolId);

            var student = dbContext
                .Students
                .FirstOrDefault(s => s.Id == studnetId && s.SchoolId == schoolId);

            if (student is null)
            {
                throw new NotFoundException("Student not found");
            }

            return student;
        }
    }

    
}
