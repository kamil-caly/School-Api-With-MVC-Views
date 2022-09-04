using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolTaskModels.Dtos;
using System.Net;

namespace SchoolTask.Views.Controllers
{
    public class StudentController : Controller
    {
        private HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:44304/api/school";
        private int SchoolId;
        public StudentController()
        {
            httpClient = new HttpClient();
        }

        // GET
        public async Task<IActionResult> Index(int schoolId)
        {
            this.SchoolId = schoolId;
            using var result = await httpClient.GetAsync(baseUrl + $"/{schoolId}/student");
            var jsonStudentDtos = await result.Content.ReadAsStringAsync();

            IEnumerable<StudentDto> studentDtos = JsonConvert.DeserializeObject<List<StudentDto>>(jsonStudentDtos);

            return View(studentDtos);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            using var postResult = await httpClient.PostAsJsonAsync<CreateStudentDto>(baseUrl + $"/{SchoolId}/student", dto);

            if (postResult.StatusCode == HttpStatusCode.Created)
            {
                TempData["info"] = "Student created successfully";
            }
            else
            {
                TempData["info"] = $"{postResult.StatusCode}";
            }

            return RedirectToAction("Index", SchoolId);
        }

    }
}
