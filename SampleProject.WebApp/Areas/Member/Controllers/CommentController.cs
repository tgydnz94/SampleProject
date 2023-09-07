using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.VMs;

namespace SampleProject.WebApp.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<IdentityUser> userManager, IAppUserService appUserService, IMapper mapper, IArticleService articleService, ICommentService commentService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _mapper = mapper;
            _articleService = articleService;
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(CreateCommentVM commentVM)
        {


            var comment = _mapper.Map<Comment>(commentVM);

            _commentService.Create(comment);





            return RedirectToAction("Detail", "Article", new { id = comment.ArticleID });
        }
    }
}
