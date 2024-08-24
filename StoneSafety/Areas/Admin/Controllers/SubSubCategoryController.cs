using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.SubSubCategories;
using StoneSafety.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoneSafety.Services;
using StoneSafety.ViewModels.Products;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SubSubCategoryController : Controller
    {
        private readonly ISubSubCategoryService _subSubCategoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productService;

        public SubSubCategoryController(ISubSubCategoryService subSubCategoryService,
                                        ISubCategoryService subCategoryService,
                                        IProductService productService)
        {
            _subSubCategoryService = subSubCategoryService;
            _subCategoryService = subCategoryService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 4; 

           
            var subSubCategories = await _subSubCategoryService.GetPaginatedAsync(page, pageSize);

           
            int totalItems = await _subSubCategoryService.GetTotalCountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

         
            var response = new Paginate<SubSubCategoryVM>(subSubCategories, totalPages, page);

          
            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subCategories = await _subCategoryService.GetAllAsync(); 

            var viewModel = new SubSubCategoryCreateVM
            {
                SubCategories = subCategories.Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                })
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubSubCategoryCreateVM request)
        {
            if (!ModelState.IsValid) return View(request);

            if (await _subSubCategoryService.ExistAsync(request.Name, request.SubCategoryId))
            {
                ModelState.AddModelError("Name", "Sub-subcategory with this name already exists in this subcategory.");
                return View(request);
            }

            await _subSubCategoryService.CreateAsync(request);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subSubCategory = await _subSubCategoryService.GetByIdAsync(id);
            if (subSubCategory == null) return NotFound();

            
            var subCategories = await _subCategoryService.GetAllAsync(); 

            var viewModel = new SubSubCategoryEditVM
            {
                Id = subSubCategory.Id,
                Name = subSubCategory.Name,
                SubCategoryId = subSubCategory.SubCategoryId,
                SubCategories = subCategories.Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubSubCategoryEditVM request)
        {
            if (!ModelState.IsValid) return View(request);

            var subSubCategory = await _subSubCategoryService.GetByIdAsync(request.Id);
            if (subSubCategory == null) return NotFound();

            if (request.Name.Trim().ToLower() != subSubCategory.Name.Trim().ToLower() &&
                await _subSubCategoryService.ExistAsync(request.Name, subSubCategory.SubCategoryId, subSubCategory.Id))
            {
                ModelState.AddModelError("Name", "Sub-subcategory with this name already exists in this subcategory.");
                return View(request);
            }

            await _subSubCategoryService.UpdateAsync(request);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subSubCategoryService.DeleteAsync(id);
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
            var subSubCategory = await _subSubCategoryService.GetByIdAsync(id);
            if (subSubCategory == null) return NotFound();

            var viewModel = new SubSubCategoryDetailVM
            {
                Id = subSubCategory.Id,
                Name = subSubCategory.Name,
                SubCategoryName = subSubCategory.SubCategory?.Name ?? "Unknown", 
                CreatedDate = subSubCategory.CreatedDate.ToString("MM.dd.yyyy"),
                UpdatedDate = subSubCategory.UpdatedDate.HasValue ? subSubCategory.UpdatedDate.Value.ToString("MM.dd.yyyy") : "N/A",
                ProductCount = subSubCategory.Products.Count(), 
                Products = subSubCategory.Products.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    
                }).ToList(),
              
            };

            return View(viewModel);
        }




        [HttpGet]
        public async Task<IActionResult> GetSubSubCategories(int subCategoryId)
        {
            var subSubCategories = await _subSubCategoryService.GetBySubCategoryIdAsync(subCategoryId);
            var selectList = subSubCategories.Select(ssc => new SelectListItem
            {
                Value = ssc.Id.ToString(),
                Text = ssc.Name
            });
            return Json(selectList);
        }


    }
}
