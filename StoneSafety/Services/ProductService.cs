using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Helpers;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Categories;
using StoneSafety.ViewModels.Products;


namespace StoneSafety.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task CreateAsync(Product product, IEnumerable<IFormFile> newImages)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (string.IsNullOrEmpty(product.ProductCode)) throw new ArgumentException("ProductCode must be provided.");

            product.ProductImages = new List<ProductImage>();

            try
            {
                if (newImages != null && newImages.Any())
                {
                    bool isFirstImage = true;
                    foreach (var file in newImages)
                    {
                        string fileName = $"{Guid.NewGuid()}-{file.FileName}";
                        string path = Path.Combine(_env.WebRootPath, "assets/images", fileName);

                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var productImage = new ProductImage
                        {
                            Name = fileName,
                            IsMain = isFirstImage,
                            Product = product
                        };

                        product.ProductImages.Add(productImage);
                        isFirstImage = false;
                    }
                }

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new InvalidOperationException("An error occurred while saving the product.", ex);
            }
        }



        public async Task DeleteProductAsync(Product product)
        {
            if (product.ProductImages != null)
            {
                foreach (var image in product.ProductImages)
                {
                    string imagePath = Path.Combine(_env.WebRootPath, "assets/images", image.Name);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }


        public async Task EditAsync(ProductEditVM data)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == data.Id);

            if (product == null) throw new Exception("Product not found");


            product.Name = data.Name;
            product.Description = data.Description;
            product.Price = data.Price;
            product.ProductCode = data.ProductCode;
            product.SubcategoryId = data.SubCategoryId;
            product.SubSubCategoryId = data.SubSubCategoryId;


            foreach (var image in data.Images)
            {
                if (image.Id != 0)
                {
                    var existingImage = product.ProductImages.FirstOrDefault(img => img.Id == image.Id);
                    if (existingImage != null)
                    {
                        existingImage.IsMain = image.IsMain;
                    }
                }
            }


            if (data.NewImages != null)
            {
                foreach (var file in data.NewImages)
                {
                    if (file.Length > 0)
                    {
                        string fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
                        string path = Path.Combine(_env.WebRootPath, "assets/images", fileName);

                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        product.ProductImages.Add(new ProductImage
                        {
                            Name = fileName,
                            IsMain = false
                        });
                    }
                }
            }


            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetBySubSubCategoryIdAsync(int subSubCategoryId)
        {
            return await _context.Products
                .Where(p => p.SubSubCategoryId == subSubCategoryId)
                .ToListAsync();
        }



        public async Task<IEnumerable<Product>> GetAllPopularAsync()
        {
            return await _context.Products
                .Where(p => p.ProductImages.Any(img => img.IsMain))
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetRandomProductsAsync(int count)
        {
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .ToListAsync();

            return products
                .OrderBy(p => Guid.NewGuid())
                .Take(count)
                .ToList();
        }




        public IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product> products)
        {
            return products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages.FirstOrDefault(img => img.IsMain)?.Name,
                SubCategoryId = p.SubcategoryId.GetValueOrDefault(),
                SubCategoryName = p.Subcategory?.Name,
                SubSubCategoryId = p.SubSubCategoryId.GetValueOrDefault(),
                SubSubCategoryName = p.SubSubCategory?.Name
            });
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
        }



        public async Task<Product> GetByIdWithAllDatasAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }



        public async Task DeleteProductImageAsync(MainAndDeleteImageVM data)
        {

            var image = await _context.ProductImages.FindAsync(data.ImageId);


            if (image != null)
            {

                string imagePath = _env.GenerateFilePath("assets/images", image.Name);


                if (File.Exists(imagePath))
                {
                    try
                    {
                        File.Delete(imagePath);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Error deleting the image file: " + ex.Message);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Image file not found on the server.");
                }


                _context.ProductImages.Remove(image);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Image not found");
            }
        }


        public async Task SetMainImageAsync(MainAndDeleteImageVM data)
        {

            System.Diagnostics.Debug.WriteLine($"Received ProductId: {data.ProductId}");
            System.Diagnostics.Debug.WriteLine($"Received ImageId: {data.ImageId}");

            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == data.ProductId);

            if (product == null)
            {
                System.Diagnostics.Debug.WriteLine("Product not found");
                return;
            }


            if (product.ProductImages == null)
            {
                System.Diagnostics.Debug.WriteLine("Product has no images");
                return;
            }


            foreach (var image in product.ProductImages)
            {
                image.IsMain = false;
            }


            var mainImage = product.ProductImages.FirstOrDefault(i => i.Id == data.ImageId);
            if (mainImage != null)
            {
                mainImage.IsMain = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Image with ID {data.ImageId} not found");
            }


            System.Diagnostics.Debug.WriteLine($"Product Images Count: {product.ProductImages.Count}");
            System.Diagnostics.Debug.WriteLine($"Main Image ID: {mainImage?.Id}");

            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }



        public async Task<IEnumerable<Product>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Products
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }




        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.Subcategory.CategoryId == categoryId)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsBySubCategoryAsync(int subCategoryId)
        {
            return await _context.Products
                .Where(p => p.SubcategoryId == subCategoryId)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsBySubSubCategoryAsync(int subSubCategoryId)
        {
            return await _context.Products
                .Where(p => p.SubSubCategoryId == subSubCategoryId)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .ToListAsync();


        }

        public Task<IEnumerable<Product>> GetAPaginateAsync(int page, int take)
        {
            throw new NotImplementedException();
        }
    }
}
