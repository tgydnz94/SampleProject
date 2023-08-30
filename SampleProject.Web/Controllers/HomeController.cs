using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleProject.Business.Abstract;
using SampleProject.Dal.Abstract;
using SampleProject.Web.Models;
using SampleProject.Web.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAppUserService _appUserService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAppUserService appUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserService = appUserService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await _userManager.FindByEmailAsync(loginDTO.Mail);

                if (identityUser != null)
                {
                    await _signInManager.SignOutAsync();   // içeride cookide kalanlaı temizliyor.

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(identityUser, loginDTO.Password, true, true);

                    if (result.Succeeded)
                    {

                        if (await _userManager.IsInRoleAsync(identityUser, "Admin"))
                        {
                            return RedirectToAction("Index", "Admin", new { area = "Admin" });
                        }
                        else if (await _userManager.IsInRoleAsync(identityUser, "Member"))
                        {
                            string role = (await _userManager.GetRolesAsync(identityUser)).FirstOrDefault();

                            return RedirectToAction("Index", "AppUser", new { area = role });   // kayıtlı kullanıcı anasayfası
                        }


                    }
                    //if (await _userManager.IsInRoleAsync("Admin"))
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}

                }

            }
            return View(loginDTO);
        }





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
