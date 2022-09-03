using AutoMapper;
using SchoolTask.Entities;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Services
{
    public interface IStudetnService
    {
        List<StudentDto> GetAll(int schoolId, string name);
        int Create(int schoolId, CreateStudentDto dto);
    }
    public class StudentService : IStudetnService
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public StudentService(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<StudentDto> GetAll(int schoolId, string name)
        {
            var school = this.GetSchoolById(schoolId);

            if(school is null)
            {
                return null;
            }

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
            var school = this.GetSchoolById(schoolId);

            var studentEntity = mapper.Map<Student>(dto);

            studentEntity.SchoolId = schoolId;

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return studentEntity.Id;
        }

        private School GetSchoolById(int schoolId)
        {
            var school = dbContext
                .Schools
                .FirstOrDefault(s => s.Id == schoolId);

            if (school is null)
            {
                throw new Exception("School not found");
            }

            return school;
        }
    }

    
}
