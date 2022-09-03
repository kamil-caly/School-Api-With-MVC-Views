using SchoolTaskModels.Dtos;

namespace SchoolTask.Interfaces
{
    public interface ISchoolService
    {
        List<SchoolDto> GetAll();
        SchoolDto GetById(int id);
        int CreateSchool(CreateSchoolDto school);
        bool UpdateSchool(UpdateSchoolDto school, int id);
        void DeleteSchool(int id);
    }
}
