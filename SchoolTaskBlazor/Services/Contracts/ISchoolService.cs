using SchoolTaskModels.Dtos;

namespace SchoolTaskBlazor.Services.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetAll();
        Task<SchoolDto> Get(int id);
    }
}
