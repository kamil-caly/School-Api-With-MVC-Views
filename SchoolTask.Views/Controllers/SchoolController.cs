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
                TempData["info"] = "School created successfully";
            }
            else
            {
                TempData["info"] = $"{postResult.StatusCode}";
            }

            return RedirectToAction("Index");
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            using var result = await httpClient.GetAsync(baseUrl + $"/{id}");
            var jsonSchoolDto = await result.Content.ReadAsStringAsync();

            if (jsonSchoolDto is null)
            {
                TempData["info"] = $"{result.StatusCode}";
                RedirectToAction("Index");
            }

            SchoolDto schoolDto = JsonConvert.DeserializeObject<SchoolDto>(jsonSchoolDto);

            return View(schoolDto);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            using var deleteResult = await httpClient.DeleteAsync(baseUrl + $"/{id}");
            var statusCode = deleteResult.StatusCode;

            if (statusCode == HttpStatusCode.NoContent)
            {
                TempData["info"] = "School deleted successfully";
            }
            else
            {
                TempData["info"] = $"{statusCode}";
            }

            return RedirectToAction("Index");
        }

        // GET
        public async Task<IActionResult> Edit(int id)
        {
            using var result = await httpClient.GetAsync(baseUrl + $"/{id}");
            var jsonSchoolDto = await result.Content.ReadAsStringAsync();

            if (jsonSchoolDto is null)
            {
                TempData["info"] = $"{result.StatusCode}";
                RedirectToAction("Index");
            }

            SchoolDto schoolDto = JsonConvert.DeserializeObject<SchoolDto>(jsonSchoolDto);

            return View(schoolDto);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Edit(SchoolDto dto)
        {
            UpdateSchoolDto updateDto = new()
            {
                FullName = dto.FullName,
                City = dto.City,
                Street = dto.Street
            };

            using var updateResult = await httpClient.PutAsJsonAsync<UpdateSchoolDto>(baseUrl + $"/{dto.Id}", updateDto);

            if (updateResult.StatusCode == HttpStatusCode.OK)
            {
                TempData["info"] = "School updated successfully";
            }
            else
            {
                TempData["info"] = $"{updateResult.StatusCode}";
            }

            return RedirectToAction("Index");
        }
    }
}
