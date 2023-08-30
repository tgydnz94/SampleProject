using AutoMapper;
using SampleProject.Entities.Concrete;
using SampleProject.Web.Models.DTOs;

namespace SampleProject.Web.Models.Mapping
{
    public class MappingWithMapper : Profile
    {
        public MappingWithMapper()
        {
            CreateMap<CreateUserDto, AppUser>();

            //CreateMap<ArticleCreateVM, Article>();
            //CreateMap<ArticleUpdateVM, Article>().ReverseMap();


        }
    }
}
