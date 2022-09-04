using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolTaskModels.Dtos;
using System.Net;

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

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateSchoolDto dto)
        {
            // var postJsonContent = new StringContent(JsonConvert.SerializeObject(dto));

            using var postResult = await httpClient.PostAsJsonAsync<CreateSchoolDto>("https://localhost:44304/api/school", dto);
            
            if (postResult.StatusCode == HttpStatusCode.Created)
            {
                TempData["info"] = "Category created successfully";
            }
            else
            {
                TempData["info"] = $"{postResult.StatusCode}";

            }

            return RedirectToAction("Index");
        }
    }
}
