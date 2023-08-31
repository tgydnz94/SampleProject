using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.Dal.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.VMs;
using System.Data;
using System.Threading.Tasks;

namespace SampleProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class ArticleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly ILikeService _likeService;
        public ArticleController(UserManager<IdentityUser> userManager, IAppUserService appUserService, ICategoryService categoryService, IMapper mapper, IArticleService articleService, ILikeService likeService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _categoryService = categoryService;
            _mapper = mapper;
            _articleService = articleService;
            _likeService = likeService;
        }
        public async Task<IActionResult> List()
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            Category category = _categoryService.GetDefault(a => a.Statu != Statu.InActive);


            var list = _articleService.GetByDefaults
                (
                    selector: a => new GetArticleVM()
                    {
                        ArticleID = a.ID,
                        CategoryName = a.Category.Name,
                        FullName = a.AppUser.FullName,
                        Title = a.Title,
                        Image = a.Image
                    },
                    expression: a => a.Statu != Statu.InActive,
                    include: a => a.Include(a => a.Category).Include(a => a.AppUser)

                );
            return View(list);
        }
        public IActionResult Delete(int id)
        {
            Article article = _articleService.GetDefault(a => a.ID == id);
            _articleService.Delete(article);
            return RedirectToAction("List");

        }

        public IActionResult Detail(int id)
        {
            var article = _articleService.GetByDefault
                (
                    selector: a => new ArticleDetailVM()
                    {
                        ArticleID = a.ID,
                        Title = a.Title,
                        CreatedDate = a.CreatedDate,
                        Image = a.Image,
                        Content = a.Content,
                        Likes = a.Likes,
                        CategoryId = a.CategoryID,
                        CategoryName = a.Category.Name,
                        UserCreatedDate = a.AppUser.CreatedDate,
                        UserId = a.AppUserID,
                        UserImage = a.AppUser.Image,
                        UserFullName = a.AppUser.FullName
                    },
                    expression: a => a.Statu != Statu.InActive && a.ID == id,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)
                );
            return View(article);

        }
    }
}
