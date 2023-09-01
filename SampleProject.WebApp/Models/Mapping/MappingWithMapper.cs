using AutoMapper;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using SampleProject.WebApp.Areas.Member.Models.VMs;
using SampleProject.WebApp.Models.DTOs;

namespace SampleProject.WebApp.Models.Mapping

{
    public class MappingWithMapper : Profile
    {
        public MappingWithMapper()
        {
            CreateMap<CreateUserDto, AppUser>();
            CreateMap<UserUpdateVM, AppUser>().ReverseMap();

            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

            CreateMap<ArticleCreateVM, Article>();
            CreateMap<ArticleUpdateVM, Article>().ReverseMap();



        }
    }
}

