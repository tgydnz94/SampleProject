using System.Collections.Generic;

namespace SampleProject.WebApp.Areas.Member.Models.DTOs
{
    public class CategoryFollowDTO
    {
        public List<CategoryFollowDTO> Follows { get; set; }
        public List<CategoryFollowDTO> UnFollows { get; set; }
    }
}
