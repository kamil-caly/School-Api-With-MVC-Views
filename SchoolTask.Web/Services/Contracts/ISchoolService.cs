using SchoolTask.Models;

namespace SchoolTask.Web.Services.Contracts
{
    public class ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetSchools();
    }
}
