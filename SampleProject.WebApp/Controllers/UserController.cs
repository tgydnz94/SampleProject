using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Models.DTOs;
using System.Threading.Tasks;
using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace SampleProject.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        public UserController(UserManager<IdentityUser> userManager, IMapper mapper, IAppUserService appUserService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {
                string newId = Guid.NewGuid().ToString();
                IdentityUser identityUser = new IdentityUser() { Email = dto.Mail, UserName = dto.UserName, Id = newId };
                IdentityResult result = await _userManager.CreateAsync(identityUser, dto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Member");   // member rolünü eklemiş olduk

                    var user = _mapper.Map<AppUser>(dto);
                    user.IdentityId = newId;

                    using var image = Image.Load(dto.ImagePath.OpenReadStream());  // fotogratfı yükleyip okumuş olduk
                    image.Mutate(a => a.Resize(80, 80));     // mutate : şekillendirmek
                    image.Save($"wwwroot/images/{user.UserName}.jpg");

                    user.Image = $"/images/{user.UserName}.jpg";

                    _appUserService.Create(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(dto);
        }
    }
}
