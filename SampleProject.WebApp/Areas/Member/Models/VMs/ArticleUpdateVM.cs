using Microsoft.AspNetCore.Http;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class ArticleUpdateVM
    {

        // ARTICLE 

        public int ID { get; set; }

        [Required(ErrorMessage = "Başlık bilgiisi boş olamaz.")]
        [MinLength(3, ErrorMessage = "Başlık bilgisi 3 karakterden az olmaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik bilgiisi boş olamaz.")]
        [MinLength(30, ErrorMessage = "İçerik bilgisi 30 karakterden az olmaz")]
        public string Content { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Fotoğraf bilgisi dolu gelmelidir.")]
        [NotMapped]
        public IFormFile ImagePath { get; set; }

        // CATEGORY

        [Required(ErrorMessage = "Categori seçimi yapınız.")]
        public int CategoryId { get; set; }      // bir kategori seçilmiş olmalı bu yüzden bu alan required !

        public List<GetCategoryDTO> Categories { get; set; } // amaç : categoryleri viewa taşımak , posta gelmeleri gerekmiyor, required değiller.


        // APPUSER

        [Required]
        public int AppUserID { get; set; }









    }
}
