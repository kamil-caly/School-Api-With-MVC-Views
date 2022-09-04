using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Views.Controllers
{
    public class SchoolController : Controller
    {
        private HttpClient httpClient;
        public SchoolController()
        {
             httpClient = new HttpClient();
        }

        // GET
        public async Task<IActionResult> Index()
        {
            using var result = await httpClient.GetAsync("https://localhost:44304/api/school");
            var jsonSchoolsDtos = await result.Content.ReadAsStringAsync();

            IEnumerable<SchoolDto> schoolDtos = JsonConvert.DeserializeObject<List<SchoolDto>>(jsonSchoolsDtos);

            return View(schoolDtos);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }
    }
}
