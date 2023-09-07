using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.Dal.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using System.Data;

namespace SampleProject.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ("Admin"))]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;

        public CategoryController(IMapper mapper, ICategoryService categoryService, UserManager<IdentityUser> userManager, IAppUserService appUserService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _userManager = userManager;
            _appUserService = appUserService;
        }
        public IActionResult GetList()
        {
            var list = _categoryService.GetDefaults(a => a.Statu != Statu.InActive);
            return View(list);
        }
        public IActionResult GetListPassive()
        {
            var list = _categoryService.GetDefaults(a => a.Statu == Statu.InActive);
            return View(list);
        }


        public IActionResult Delete(int id)
        {
            Category category = _categoryService.GetDefault(a => a.ID == id);
            _categoryService.Delete(category);
            return RedirectToAction("GetList");
        }
        public IActionResult Activate(int id)
        {
            Category category = _categoryService.GetDefault(a => a.ID == id);
            _categoryService.Update(category);
            return RedirectToAction("GetList");
        }
    }
}
