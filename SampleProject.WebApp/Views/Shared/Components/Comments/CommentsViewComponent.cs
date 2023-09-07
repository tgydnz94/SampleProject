using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.WebApp.Models.VMs;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SampleProject.WebApp.Views.Shared.Components.Comments
{
    [ViewComponent(Name = "Comments")]
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {

            List<GetCommentWithUserVM> comments = _commentService.GetByDefaults
                (
                    selector: p => new GetCommentWithUserVM()
                    {
                        Text = p.Text,
                        AppUserID = p.AppUserID,
                        ArticleID = p.ArticleID,
                        UserFullName = p.AppUser.FullName,
                        CreatedDate = p.CreatedDate,
                        Image = p.AppUser.Image
                    },
                    expression: p => p.Statu != Statu.InActive && p.ArticleID == id,
                    include: p => p.Include(p => p.AppUser),
                    orderBy: p => p.OrderByDescending(p => p.CreatedDate)
                ).Take(5).ToList();

            return View(comments);
        }
    }
}
