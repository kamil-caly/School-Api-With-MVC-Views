using System.ComponentModel.DataAnnotations;

namespace SchoolTaskModels.Dtos
{
    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required]
        [MaxLength(6)]
        public string StudentIndex { get; set; }
    }
}
