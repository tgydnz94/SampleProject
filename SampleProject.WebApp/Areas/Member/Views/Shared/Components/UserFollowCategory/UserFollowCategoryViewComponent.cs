using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Dal.Abstract;
using System.Xml.Linq;

namespace SampleProject.WebApp.Areas.Member.Views.Shared.Components.UserFollowCategory
{
    [ViewComponent(Name = "UserFollowCategory")]
    public class UserFollowCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;


        // coookide olan kullanıcının takip ettiği kategorileri gösterelim

        public UserFollowCategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public IViewComponentResult Invoke(int id)   // id => appuser ıd
        {

            var list = _categoryService.GetCategoriesWithUser(id);

            return View(list);

        }





    }
}
