using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.Dal.Abstract;
using SampleProject.Entities.Concrete;
using System.Data;
using System.Threading.Tasks;

namespace SampleProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;

        public UserController(IMapper mapper, ICategoryService categoryService, UserManager<IdentityUser> userManager, IAppUserService appUserService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _userManager = userManager;
            _appUserService = appUserService;
        }

        public IActionResult List()
        {
            var list = _appUserService.GetDefaults(a => a.Statu != Statu.InActive);
            return View(list);
        }

        public IActionResult DeleteList()
        {
            var list = _appUserService.GetDefaults(a => a.Statu == Statu.InActive);
            return View(list);
        }
        public async Task<IActionResult> Delete(int id)
        {
            AppUser appUser = _appUserService.GetDefault(a => a.ID == id);
            IdentityUser identityUser = await _userManager.FindByIdAsync(appUser.IdentityId);

            if (appUser != null)
            {
                _appUserService.Delete(appUser);
                _userManager.DeleteAsync(identityUser);
                return RedirectToAction("List", "User");
            }




            return RedirectToAction("List", "User");
        }
    }
}
