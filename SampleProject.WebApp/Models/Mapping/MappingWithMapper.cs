using AutoMapper;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Models.DTOs;

namespace SampleProject.WebApp.Models.Mapping

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

