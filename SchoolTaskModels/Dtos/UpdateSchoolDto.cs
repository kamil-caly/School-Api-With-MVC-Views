using System.ComponentModel.DataAnnotations;

namespace SchoolTaskModels.Dtos
{
    public class UpdateSchoolDto
    {
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
    }
}
