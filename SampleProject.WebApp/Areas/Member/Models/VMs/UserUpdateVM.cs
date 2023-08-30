using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class UserUpdateVM
    {
        public int ID { get; set; }


        public string IdentityId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")]
        [MaxLength(50, ErrorMessage = "En fazla 50  karakter yazabilirsiniz")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")]
        [MaxLength(50, ErrorMessage = "En fazla 50  karakter yazabilirsiniz")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")]
        [MaxLength(50, ErrorMessage = "En fazla 50  karakter yazabilirsiniz")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter yazmalısınız")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string Image { get; set; }



        [Required(ErrorMessage = "Dosya yolu geçersiz.")]
        [NotMapped]
        public IFormFile ImagePath { get; set; }


        [Required(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
    }
}
