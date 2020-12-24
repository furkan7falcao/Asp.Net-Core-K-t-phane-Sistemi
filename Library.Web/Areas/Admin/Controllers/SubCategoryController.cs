using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Library.Business.Interfaces;
using Library.DTO.DTOs.SubCategoryDtos;
using Library.Entities.Concreate;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetSubCategoriesOfBaseCategory(int BaseCategoryId)
        {
            TempData["Active"] = "category";

            var db_Subcategories = await _subCategoryService.GetSubCategoriesOfBaseCategoryWithIdAsync(BaseCategoryId);

            var SubcategoryList = new List<SubCategoryListDto>();

            foreach (var db_Subcategory in db_Subcategories)
            {
                var subCategory = new SubCategoryListDto();

                subCategory.Id = db_Subcategory.Id;
                subCategory.Name = db_Subcategory.Name;

                SubcategoryList.Add(subCategory);
            }

            var jsonCategories = JsonConvert.SerializeObject(SubcategoryList);

            return Json(jsonCategories);
        }


        [HttpGet]
        public async Task<IActionResult> Add(int baseCategoryId)
        {
            TempData["Active"] = "category";

            var getBaseCategory = await _categoryService.FindByIdAsync(baseCategoryId);

            var updatedCategory = new SubCategoryAddDto
            {
                Category = getBaseCategory,
                CategoryId = getBaseCategory.Id,
                Name = String.Empty
            };

            return View(updatedCategory);

        }


        [HttpPost]
        public async Task<IActionResult> Add(SubCategoryAddDto model)
        {
            TempData["Active"] = "category";

            if (ModelState.IsValid)
            {
                await _subCategoryService.AddAsync(_mapper.Map<SubCategoryAddDto, SubCategory>(model));

                return RedirectToAction("Update", new RouteValueDictionary(
                    new { controller = "Category", action = "Update", id = model.CategoryId }));
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            TempData["Active"] = "category";

            var getCategory = await _subCategoryService.GetSubCategoryWithIdAsync(id);

            var updatedCategory = new SubCategoryUpdateDto
            {
                Id = getCategory.Id,
                Name = getCategory.Name,
                CategoryId=getCategory.CategoryId
            };

            return View(updatedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubCategoryUpdateDto model)
        {
            TempData["Active"] = "category";

            if (ModelState.IsValid)
            {
                await _subCategoryService.UpdateAsync(_mapper.Map<SubCategoryUpdateDto, SubCategory>(model));

                return RedirectToAction("Index", "Category");
            }

            return View(model);

        }

    }
}
