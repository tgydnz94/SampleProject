using System.ComponentModel.DataAnnotations;

namespace SampleProject.Web.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Bu alan boş olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Bu alan boş olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
