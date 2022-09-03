using System.ComponentModel.DataAnnotations;

namespace SchoolTaskModels.Dtos
{
    public class CreateSchoolDto
    {
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public string SchoolType { get; set; }
    }
}
