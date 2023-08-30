using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Areas.Member.Models.DTOs
{
    public class UpdateCategoryDTO
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamzsınız")]
        [MinLength(3, ErrorMessage = "En az  3 karakter yazmak zorundasınız.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bu alanı boş bırakamzsınız")]
        [MinLength(10, ErrorMessage = "En az  10 karakter yazmak zorundasınız.")]
        public string Description { get; set; }




    }
}
