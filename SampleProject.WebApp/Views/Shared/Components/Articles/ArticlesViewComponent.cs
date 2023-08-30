using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.WebApp.Models.VMs;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SampleProject.WebApp.Views.Shared.Components.Articles
{
    [ViewComponent(Name = "Articles")]
    public class ArticlesViewComponent : ViewComponent
    {

        // en güncel 10 makaleyi card gibi yapılarla hem anasayfada hem de member area içindeki anasayfada göstermek istiyorum.

        private readonly IArticleService _articleService;
        public ArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            List<GetArticleWithUserVM> listem = _articleService.GetByDefaults
                (
                    selector: a => new GetArticleWithUserVM()
                    {
                        Title = a.Title,
                        Content = a.Content,
                        CreatedDate = a.CreatedDate,
                        ArticleID = a.ID,
                        Image = a.Image,
                        UserFullName = a.AppUser.FullName,
                        AppUserID = a.AppUserID
                    },
                    expression: a => a.Statu != Statu.InActive,
                    include: a => a.Include(a => a.AppUser),
                    orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                ).Take(10).ToList();

            return View(listem);


        }

    }
}
