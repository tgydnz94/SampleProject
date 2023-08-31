using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Dal.Abstract;
using SampleProject.Entities.Concrete;
using System.Data;
using System.Threading.Tasks;

namespace SampleProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public AdminController(UserManager<IdentityUser> userManager, IAppUserService appUserService, SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _signInManager = signInManager;
            _mapper = mapper;
        }



        public async Task<IActionResult> Index()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == identityUser.Id);

            if (identityUser != null) return View(appUser);

            return Redirect("~/");   /* RedirectToAction("Index", "Home");*/
        }
    }
}
