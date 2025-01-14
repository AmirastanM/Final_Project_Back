﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Categories;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Helpers;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var categories = await _categoryService.GetAllPaginateAsync(page, 4);
            var mappedDatas = _categoryService.GetMappedDatas(categories);
            var totalPage = await GetPageCountAsync(4);

            Paginate<CategorySubCategoryVM> response = new(mappedDatas, totalPage, page);
            return View(response);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(CategoryCreateVM request)
        {
            if (!ModelState.IsValid)
                return View(request);

            if (await _categoryService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                return View(request);
            }

            if (request.Image != null && !request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View(request);
            }

         

            await _categoryService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);
            if (category is null) return NotFound();

            return View(new CategoryEditVM
            {
                Name = category.Name,
                Image = category.Image
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);
            if (category is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = category.Image;
                return View(request);
            }

            if (request.Name.Trim().ToLower() != category.Name.Trim().ToLower() && await _categoryService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                request.Image = category.Image;
                return View(request);
            }

            if (request.NewImage != null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Input can accept only image format");
                    request.Image = category.Image;
                    return View(request);
                }

                if (!request.NewImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("NewImage", "Image size must be max 200 KB");
                    request.Image = category.Image;
                    return View(request);
                }
            }

            await _categoryService.EditAsync(category, request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);
            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdWithHierarchyAsync((int)id);
            if (category is null) return NotFound();

            return View(new CategoryDetailVM
            {
                Name = category.Name,
                CreatedDate = category.CreatedDate.ToString("MM.dd.yyyy"),
                UpdatedDate = category.UpdatedDate.HasValue ? category.UpdatedDate.Value.ToString("MM.dd.yyyy") : "N/A",
                Image = category.Image,
                SubCategories = category.SubCategories.Select(sc => sc.Name).ToList()
            });
        }


        private async Task<int> GetPageCountAsync(int take)
        {
            int categoryCount = await _categoryService.GetCountAsync();
            return (int)Math.Ceiling((decimal)categoryCount / take);
        }
    }
}
