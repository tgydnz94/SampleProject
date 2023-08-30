using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Areas.Member.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "Bu alana en az 3 karakterlik veri girişi yapılacaktır.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [MinLength(10, ErrorMessage = "Bu alana en az 10 karakterlik veri girişi yapılacaktır.")]
        public string Description { get; set; }
    }
}
