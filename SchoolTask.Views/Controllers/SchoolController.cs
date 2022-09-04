using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolTaskModels.Dtos;
using System.Net;

namespace SchoolTask.Views.Controllers
{
    public class SchoolController : Controller
    {
        private HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:44304/api/school";
        public SchoolController()
        {
            httpClient = new HttpClient();
        }

        // GET
        public async Task<IActionResult> Index()
        {
            using var result = await httpClient.GetAsync(baseUrl);
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
            using var postResult = await httpClient.PostAsJsonAsync<CreateSchoolDto>(baseUrl, dto);
            
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
