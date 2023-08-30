using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using System.Threading.Tasks;
using System;
using SampleProject.WebApp.Areas.Member.Models.VMs;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using SampleProject.Core.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace SampleProject.WebApp.Areas.Member.Controllers
{
    [Area("Member")]
    public class ArticleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ILikeService _likeService;
        private readonly ICommentService _commentService;

        public ArticleController(UserManager<IdentityUser> userManager, IAppUserService appUserService, ICategoryService categoryService, IMapper mapper, IArticleService articleService, ILikeService likeService, ICommentService commentService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserService = appUserService;
            _categoryService = categoryService;
            _articleService = articleService;
            _likeService = likeService;
            _commentService = commentService;

        }
        public async Task<IActionResult> Create()
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == user.Id);


            ArticleCreateVM vm = new ArticleCreateVM()
            {
                AppUserID = appUser.ID,
                Categories = _categoryService.GetByDefaults
                (
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.InActive
                )
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(vm);

                using var image = Image.Load(vm.ImagePath.OpenReadStream());  // fotoğrafı yükleyip okuduk
                image.Mutate(a => a.Resize(80, 80));

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpeg");

                article.Image = $"/images/{guid}.jpeg";

                _articleService.Create(article);
                return RedirectToAction("List");

            }
            vm.Categories = _categoryService.GetByDefaults
                (
                 selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.InActive
                );
            return View(vm);
        }


        public async Task<IActionResult> List()   // kişinn kendi makalelerini göstermek istiyoruz !
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == user.Id);


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
                    expression: a => a.Statu != Statu.InActive && a.AppUserID == appUser.ID,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)

                );
            return View(list);
            // todo: categoryde kullandığımız list şablonunu kullanalım.
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Article article = _articleService.GetDefault(a => a.ID == id);

            var updatedArticle = _mapper.Map<ArticleUpdateVM>(article);

            updatedArticle.Categories = _categoryService.GetByDefaults
                (
                    selector: a => new GetCategoryDTO { ID = a.ID, Name = a.Name },
                    expression: a => a.Statu != Statu.InActive
                );
            return View(updatedArticle);

        }

        [HttpPost]
        public IActionResult Update(ArticleUpdateVM vm)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(vm);

                using var image = Image.Load(vm.ImagePath.OpenReadStream());   // fotoğrfaı okuyup yükledik.
                image.Mutate(a => a.Resize(80, 80));

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpeg");
                article.Image = $"/images/{guid}.jpeg";

                _articleService.Update(article);
                return RedirectToAction("List");

            }
            return View(vm);

            // todo : negatif senoryada yani validasyon kurallarına uyulmadığı zaaman categories null gelecek ve bu html  foreachte hata yaratacak.

            // todo : makale foroğrafını güncellmezse ?
            // todo : makale fotoğrafını güncellerse , eski makale fotoğrafını silelim ki proje şişmesin ?!

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

        public async Task<IActionResult> Like(int id)
        {
            Article article = _articleService.GetDefault(a => a.ID == id);

            IdentityUser user = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == user.Id);

            Like like = new Like() { AppUser = appUser, AppUserID = appUser.ID, Article = article, ArticleID = id };

            _likeService.Create(like);
            return RedirectToAction("Detail", new { id = id });
        }


        public async Task<IActionResult> Unlike(int id)
        {
            Article article = _articleService.GetDefault(a => a.ID == id);

            IdentityUser user = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == user.Id);

            Like like = _likeService.GetDefault(a => a.ArticleID == id && a.AppUserID == appUser.ID);

            _likeService.Delete(like);
            return RedirectToAction("Detail", new { id = id });  // detail actionı bizden id bekleyecektir. aldığımız makale id yi onunla paylaştık.

        }
    }
}
