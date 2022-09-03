using SchoolTaskBlazor.Services.Contracts;
using SchoolTaskModels.Dtos;
using System.Net.Http.Json;

namespace SchoolTaskBlazor.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly HttpClient httpClient;

        public SchoolService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<SchoolDto> Get(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/School/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(SchoolDto);
                    }

                    return await response.Content.ReadFromJsonAsync<SchoolDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SchoolDto>> GetAll()
        {
            try
            {
                var schools = await httpClient
                    .GetFromJsonAsync<IEnumerable<SchoolDto>>("api/school");

                return schools;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
