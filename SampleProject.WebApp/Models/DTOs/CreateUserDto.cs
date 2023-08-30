using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.WebApp.Models.DTOs
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
    }
}
