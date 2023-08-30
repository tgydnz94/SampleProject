using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.WebApp.Models.VMs;

namespace SampleProject.WebApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public ArticleController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }


        public IActionResult Detail(int id)  // id => makale id
        {
            ViewBag.Id = id;
            var article = _articleService.GetByDefault
                (
                    selector: a => new ArticleDetailVM() { ArticleId = a.ID, Title = a.Title, Content = a.Content, Image = a.Image, CreatedDate = a.CreatedDate, Likes = a.Likes, CategoryName = a.Category.Name, UserFullName = a.AppUser.FullName, UserId = a.AppUserID, UserImage = a.AppUser.Image },
                    expression: a => a.Statu != Statu.InActive && a.ID == id,
                    include: a => a.Include(a => a.AppUser).Include(a => a.Category)
                );

            return View(article);

        }
        public IActionResult CommentView(int id)
        {
            var comment = _commentService.GetByDefault
                (
                    selector: p => new GetCommentWithUserVM()
                    {
                        ArticleID = p.ArticleID,
                        Text = p.Text,
                        AppUserID = p.AppUserID,
                        Image = p.AppUser.Image,
                        CreatedDate = p.CreatedDate,
                        UserFullName = p.AppUser.FullName,
                    },
                    expression: p => p.Statu != Statu.InActive && p.ArticleID == id,
                    include: p => p.Include(p => p.AppUser).Include(p => p.Article)
                );
            return View(comment);
        }
    }
}

