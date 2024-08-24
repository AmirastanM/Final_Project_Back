using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Helpers;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Products;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ISubSubCategoryService _subSubCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService,
                                 ISubCategoryService subCategoryService,
                                 ISubSubCategoryService subSubCategoryService,
                                 ICategoryService categoryService,
                                 IWebHostEnvironment env)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
            _subSubCategoryService = subSubCategoryService;
            _categoryService = categoryService;
            _env = env;
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

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _productService.GetAllPaginateAsync(page, 4);

            var mappedDatas = products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages.FirstOrDefault(img => img.IsMain)?.Name,
                Description = p.Description,
                ProductCode = p.ProductCode,
                Rating = p.Rating,
                SubCategoryName = p.Subcategory?.Name,
                SubSubCategoryName = p.SubSubCategory?.Name
            });

            var totalPage = await GetPageCountAsync(4);
            var response = new Paginate<ProductVM>(mappedDatas, totalPage, page);

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.GetByIdWithAllDatasAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.ProductImages.FirstOrDefault(img => img.IsMain)?.Name,
                Rating = product.Rating,
                SubCategoryName = product.Subcategory?.Name ?? "N/A",
                SubSubCategoryName = product.SubSubCategory?.Name ?? "N/A",
                CreatedDate = product.CreatedDate.ToString("yyyy-MM-dd"),
                UpdatedDate = product.UpdatedDate.HasValue ? product.UpdatedDate.Value.ToString("yyyy-MM-dd") : "N/A",
                Images = product.ProductImages.Select(img => img.Name).ToList()
            };

            return View(viewModel);
        }







        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subCategories = await _subCategoryService.GetAllSelectListAsync();
            var viewModel = new ProductCreateVM
            {
                SubCategories = subCategories,
                SubSubCategories = Enumerable.Empty<SelectListItem>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    ProductCode = model.ProductCode,
                    Rating = model.Rating,
                    SubcategoryId = model.SubCategoryId,
                    SubSubCategoryId = model.SubSubCategoryId
                };

                try
                {

                    await _productService.CreateAsync(product, model.NewImages);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while creating the product.");
                }
            }


            model.SubCategories = await _subCategoryService.GetAllSelectListAsync();
            model.SubSubCategories = model.SubCategoryId.HasValue
                ? (await _subSubCategoryService.GetBySubCategoryIdAsync(model.SubCategoryId.Value))
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    })
                : Enumerable.Empty<SelectListItem>();

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var subCategories = await _subCategoryService.GetAllSelectListAsync();
            var subSubCategories = product.SubcategoryId.HasValue
                ? await _subSubCategoryService.GetBySubCategoryIdAsync(product.SubcategoryId.Value)
                : Enumerable.Empty<SubSubCategory>();

            var currentImage = product.ProductImages.FirstOrDefault(img => img.IsMain)?.Name ?? string.Empty;


            var productEditVM = new ProductEditVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductCode = product.ProductCode,
                CurrentImage = currentImage,
                SubCategoryId = product.SubcategoryId ?? 0,
                SubSubCategoryId = product.SubSubCategoryId ?? 0,
                SubCategories = subCategories,
                SubSubCategories = subSubCategories.Select(ssc => new SelectListItem
                {
                    Value = ssc.Id.ToString(),
                    Text = ssc.Name
                }),
                Images = product.ProductImages.Select(m => new ProductImageEditVM
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsMain = m.IsMain,
                    ProductId = m.ProductId
                }).ToList()
            };

            return View(productEditVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.EditAsync(model);

                    var mainImage = model.Images.FirstOrDefault(img => img.IsMain);
                    if (mainImage != null)
                    {
                        var mainImageData = new MainAndDeleteImageVM
                        {
                            ProductId = model.Id,
                            ImageId = mainImage.Id
                        };

                        await _productService.SetMainImageAsync(mainImageData);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while updating the product: {ex.Message}");
                }
            }

          
            model.SubCategories = await _subCategoryService.GetAllSelectListAsync();
            model.SubSubCategories = model.SubCategoryId.HasValue
                ? (await _subSubCategoryService.GetBySubCategoryIdAsync(model.SubCategoryId.Value))
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    })
                : Enumerable.Empty<SelectListItem>();

            return View(model);
        }










        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var product = await _productService.GetByIdAsync((int)id);
            if (product is null) return NotFound();

            await _productService.DeleteProductAsync(product);
            return Ok();
        }

        [HttpPost("admin/product/deleteimage")]
        public async Task<IActionResult> DeleteImage([FromBody] MainAndDeleteImageVM data)
        {
            try
            {
                await _productService.DeleteProductImageAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }







        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();
            return (int)Math.Ceiling((decimal)productCount / take);
        }


        [HttpPost("admin/product/setmainimage")]
        public async Task<IActionResult> SetMainImage([FromBody] MainAndDeleteImageVM data)
        {
            try
            {
                await _productService.SetMainImageAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }






    }
}
