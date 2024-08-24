using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.SubCategories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using StoneSafety.Helpers;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var subCategories = await _subCategoryService.GetAllPaginateAsync(page, 4);
            var mappedDatas = _subCategoryService.GetMappedDatas(subCategories)
                .Select(sc => new SubCategoryVM
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CreatedDate = sc.CreatedDate,
                    SubSubCategories = sc.SubSubCategories,
                    Products = sc.Products
                });

            var totalPage = await GetPageCountAsync(4);
            var response = new Paginate<SubCategoryVM>(mappedDatas, totalPage, page);

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int categoryId)
        {
            var categories = await _categoryService.GetAllAsync();

            var viewModel = new SubCategoryCreateVM
            {
                CategoryId = categoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(SubCategoryCreateVM request)
        {
            if (!ModelState.IsValid) return View(request);

            if (await _subCategoryService.ExistAsync(request.Name, request.CategoryId))
            {
                ModelState.AddModelError("Name", "Subcategory with this name already exists in this category.");
                return View(request);
            }

            await _subCategoryService.CreateAsync(request);
            return RedirectToAction("Index", "SubCategory");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subCategory = await _subCategoryService.GetByIdAsync(id);
            if (subCategory == null) return NotFound();

            var viewModel = new SubCategoryEditVM
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,
                Categories = await _categoryService.GetAllSelectListItemsAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryEditVM request)
        {
            if (!ModelState.IsValid) return View(request);

            var subCategory = await _subCategoryService.GetByIdAsync(request.Id);
            if (subCategory == null) return NotFound();

            
            if (request.Name.Trim().ToLower() != subCategory.Name.Trim().ToLower() &&
                await _subCategoryService.ExistAsync(request.Name, request.CategoryId))
            {
                ModelState.AddModelError("Name", "Subcategory with this name already exists in this category.");
                return View(request);
            }

         
            subCategory.Name = request.Name;
            subCategory.CategoryId = request.CategoryId; 

           
            await _subCategoryService.UpdateAsync(subCategory);
            return RedirectToAction("Index", "SubCategory");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid ID");
            }

            try
            {
                await _subCategoryService.DeleteByIdAsync((int)id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }







        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var subCategory = await _subCategoryService.GetByIdAsync(id);
            if (subCategory == null) return NotFound();

            var viewModel = new SubCategoryDetailVM
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryName = subCategory.Category != null ? subCategory.Category.Name : "No Category",
                Products = subCategory.Products.Select(p => p.Name).ToList(),
                CreatedDate = subCategory.CreatedDate.ToString("MM.dd.yyyy"),
                UpdatedDate = subCategory.UpdatedDate.HasValue ? subCategory.UpdatedDate.Value.ToString("MM.dd.yyyy") : "N/A",
                SubSubCategories = subCategory.SubSubCategories.Select(ssc => ssc.Name).ToList()
            };

            return View(viewModel);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int subCategoryCount = await _subCategoryService.GetCountAsync();
            return (int)Math.Ceiling((decimal)subCategoryCount / take);
        }
    }
}
