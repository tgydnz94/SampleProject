using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.VMs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Threading.Tasks;

namespace SampleProject.WebApp.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        public AppUserController(UserManager<IdentityUser> userManager, IAppUserService appUserService, SignInManager<IdentityUser> signInManager, IMapper mapper)
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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");     // RedirectToAction("Index","Home");

        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == identityUser.Id);

            var userUpdate = _mapper.Map<UserUpdateVM>(appUser);
            userUpdate.Mail = identityUser.Email;

            return View(userUpdate);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UserUpdateVM updateVM)
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.ID == updateVM.ID);

            if (ModelState.IsValid)
            {
                AppUser updateAppUser = _mapper.Map<AppUser>(updateVM);

                using var image = Image.Load(updateVM.ImagePath.OpenReadStream());
                image.Mutate(a => a.Resize(80, 80));

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpeg");
                appUser.Image = $"/images/{guid}.jpeg";

                identityUser.Email = updateVM.Mail;

                IdentityResult result = await _userManager.ChangePasswordAsync(identityUser, identityUser.PasswordHash, updateVM.Password);
                IdentityResult result2 = await _userManager.ChangeEmailAsync(identityUser, identityUser.Email, updateVM.Mail);

                _appUserService.Update(appUser);
                return RedirectToAction("Index", "AppUser");
            }
            return View(updateVM);
        }
        public IActionResult Detail(int id)
        {
            var appUser = _appUserService.GetByDefault
                (
                    selector: a => new UserDetailsVM()
                    {
                        UserId = a.ID,
                        UserImage = a.Image,
                        UserName = a.UserName,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        UserCreatedDate = a.CreatedDate
                    },
                    expression: a => a.Statu != Statu.InActive && a.ID == id,
                    include: a => a.Include(a => a.Articles).Include(a => a.IdentityId)
                );
            return View(appUser);
        }

        public async Task<IActionResult> Delete()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == identityUser.Id);

            if (identityUser != null)
            {
                _appUserService.Delete(appUser);
                _userManager.DeleteAsync(identityUser);
                return RedirectToAction("Logout", "AppUser");
            }




            return RedirectToAction("Index", "Home");
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
