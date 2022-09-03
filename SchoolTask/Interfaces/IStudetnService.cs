using SchoolTaskModels.Dtos;

namespace SchoolTask.Interfaces
{
    public interface IStudetnService
    {
        List<StudentDto> GetAll(int schoolId, string name);
        StudentDto GetById(int schoolId, int studentId);
        int Create(int schoolId, CreateStudentDto dto);
        void Update(int schoolId, int studentId, UpdateStudentDto dto);
        void Delete(int schoolId, int studentId);
    }
}
