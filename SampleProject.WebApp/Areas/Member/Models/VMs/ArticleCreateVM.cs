using Microsoft.AspNetCore.Http;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class ArticleCreateVM
    {


        // ARTICLE

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter yazmalısınız.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(200, ErrorMessage = "En az 200 karakter yazmalısınız.")]
        public string Content { get; set; }

        // bu alan boş olabilir çünkü önemli olan ıformfile ın veri çekebilmesi sonrasında kayıt için burayı kullanacağız.
        public string Image { get; set; }

        [NotMapped]  // herhangi bir sınıf propla eşleşmesin
        [Required(ErrorMessage = "Fotoğraf yüklemelisiniz!")]
        public IFormFile ImagePath { get; set; }


        // CATEGORY

        [Required(ErrorMessage = "Kategori seçimi yapmalısınız..")]
        public int CategoryID { get; set; }

        public List<GetCategoryDTO> Categories { get; set; } // her bir kategorinin tüm proplarını taşımakatansa sadece name ve id taşımak için


        // APPUSER

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public int AppUserID { get; set; }

        //Comment

        //public int CommentID { get; set; }

        //public List<GetCommentDTO> Comments { get; set; }









    }
}
