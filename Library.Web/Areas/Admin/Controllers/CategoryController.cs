using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Business.Interfaces;
using Library.DTO.DTOs.CategoryDtos;
using Library.Entities.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "category";

            var db_categories = await _categoryService.GetCategoriesWithSubCategoriesAsync();

            var categoryList = new List<CategoryListDto>();

            foreach (var db_category in db_categories)
            {
                var baseCategory = new CategoryListDto();

                baseCategory.Id = db_category.Id;
                baseCategory.Name = db_category.Name;
                baseCategory.SubCategories = db_category.SubCategories;

                categoryList.Add(baseCategory);
            }

            return View(categoryList);
        }

        
        
        [HttpGet]
        public IActionResult Add()
        {
            TempData["Active"] = "category";

            return View(new CategoryAddDto());
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto model)
        {
            TempData["Active"] = "category";

            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(_mapper.Map<CategoryAddDto, Category>(model));

                return RedirectToAction("Index", "Category");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["Active"] = "category";

            var getCategory = await _categoryService.GetCategoriesWithSubCategoriesUsingIdAsync(id);

            var updatedCategory = new CategoryUpdateDto
            {
                Name = getCategory.Name,
                Id = getCategory.Id,
                SubCategories = getCategory.SubCategories
            };

            return View(updatedCategory);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto model)
        {
            TempData["Active"] = "category";

            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDto, Category>(model));

                return RedirectToAction("Index", "Category");
            }

            return View(model);
        }

    }

}
