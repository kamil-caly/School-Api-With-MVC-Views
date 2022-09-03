using SchoolTask.Entities;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Interfaces
{
    public interface ISchoolService
    {
        List<SchoolDto> GetAll();
        School GetSchool(int id);
        SchoolDto GetById(int id);
        int CreateSchool(CreateSchoolDto school);
        void UpdateSchool(UpdateSchoolDto school, int id);
        void DeleteSchool(int id);
    }
}
