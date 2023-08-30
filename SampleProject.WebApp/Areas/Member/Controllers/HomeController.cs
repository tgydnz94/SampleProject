using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Abstract;
using SampleProject.Core.Entity.Enums;
using SampleProject.Dal.Abstract;
using SampleProject.Entities.Concrete;
using SampleProject.WebApp.Areas.Member.Models.DTOs;
using System.Threading.Tasks;

namespace SampleProject.WebApp.Areas.Member.Controllers
{
    [Area("Member")]
    public class CategoryController : Controller
    {


        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAppUserService _appUserService;

        public CategoryController(IMapper mapper, ICategoryService categoryService, UserManager<IdentityUser> userManager, IAppUserService appUserService)
        {
            _mapper = mapper;
            _categoryService=categoryService;
            _userManager = userManager;
            _appUserService= appUserService;
        }


        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(dto);
                _categoryService.Create(category);
                return RedirectToAction("List");

            }
            return View(dto);

        }


        public IActionResult List()
        {
            var list = _categoryService.GetDefaults(a => a.Statu != Statu.InActive);

            return View(list);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category = _categoryService.GetDefault(a => a.ID == id);

            //UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO();
            //updateCategoryDTO.Name = category.Name;
            //updateCategoryDTO.Description = category.Description;

            var updatedCategory = _mapper.Map<UpdateCategoryDTO>(category);
            return View(updatedCategory);


        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(dto);
                _categoryService.Update(category);
                return RedirectToAction("List");
            }
            return View(dto);
        }



        //public IActionResult Delete(int id)
        //{
        //    Category category= _categoryRepository.GetDefault(a => a.ID == id);
        //    _categoryRepository.Delete(category);
        //    return RedirectToAction("List");
        //}


        public async Task<IActionResult> Follow(int id)  // categoryId
        {
            Category category = _categoryService.GetDefault(a => a.ID == id);

            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            AppUser appUser = _appUserService.GetDefault(a => a.IdentityId == identityUser.Id);


            category.UserFollowedCategories.Add
                (
                    new UserFollowedCategories { AppUser = appUser, AppUserID = appUser.ID, Category = category, CategoryID = category.ID }

                );

            //todo: kullanıcı takip ediyorsa tekrar LİST syfasına döndüğünde o kategori için takibi bırak , takip etmed,kleri içinse takip et yazmalı ki , daha kullanıcı dostu bir deneyim olsun ve çakışan anahtarları ekleme hatasını almaktan kurtulalım çünkü ara tabloda her satır eşsizdir yani aynı satırı tekrar ekleyemezsiniz. !!!

            _categoryService.Update(category);
            return RedirectToAction("List");


        }







    }
}
