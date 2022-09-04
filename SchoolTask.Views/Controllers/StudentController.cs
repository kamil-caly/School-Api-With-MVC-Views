using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolTaskModels.Dtos;

namespace SchoolTask.Views.Controllers
{
    public class StudentController : Controller
    {
        private HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:44304/api/school";
        public StudentController()
        {
            httpClient = new HttpClient();
        }

        // GET
        public async Task<IActionResult> Index(int schoolId)
        {
            using var result = await httpClient.GetAsync(baseUrl + $"/{schoolId}/student");
            var jsonStudentDtos = await result.Content.ReadAsStringAsync();

            if (jsonStudentDtos is null)
            {
                TempData["info"] = "Any student not found";
                return RedirectToPage("School/Index");
            }

            IEnumerable<StudentDto> studentDtos = JsonConvert.DeserializeObject<List<StudentDto>>(jsonStudentDtos);

            return View(studentDtos);
        }

    }
}
