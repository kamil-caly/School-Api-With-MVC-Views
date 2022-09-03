using Microsoft.AspNetCore.Components;
using SchoolTaskBlazor.Services.Contracts;
using SchoolTaskModels.Dtos;

namespace SchoolTaskBlazor.Pages
{
    public class SchoolsBase : ComponentBase
    {
        [Inject]
        public ISchoolService schoolService { get; set; }
        public IEnumerable<SchoolDto> Schools { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Schools = await schoolService.GetAll();  
        }
    }
}
