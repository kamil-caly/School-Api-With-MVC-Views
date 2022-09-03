using Microsoft.AspNetCore.Components;
using SchoolTaskBlazor.Services.Contracts;
using SchoolTaskModels.Dtos;

namespace SchoolTaskBlazor.Pages
{
    public class SchoolBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        public ISchoolService schoolService { get; set; }
        public SchoolDto School { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                School = await schoolService.Get(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}
