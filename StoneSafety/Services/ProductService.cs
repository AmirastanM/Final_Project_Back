using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
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

        public async Task CreateAsync(ProductCreateVM data)
        {
            var product = new Product
            {
                Name = data.Name.Trim(),
                Description = data.Description.Trim(),
                Price = data.Price,
                ProductCode = data.ProductCode.Trim(),
                SubcategoryId = data.SubCategoryId,
                SubSubCategoryId = data.SubSubCategoryId
            };

            if (data.Image != null)
            {
                string fileName = $"{Guid.NewGuid()}-{data.Image.FileName}";
                string path = _env.GenerateFilePath("img/products", fileName);
                await data.Image.SaveFileToLocalAsync(path);
                product.ProductImages = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Name = fileName,
                        IsMain = true
                    }
                };
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            if (product.ProductImages != null)
            {
                foreach (var image in product.ProductImages)
                {
                    string imagePath = _env.GenerateFilePath("img/products", image.Name);
                    imagePath.DeleteFileFromLocal();
                }
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Product product, ProductEditVM data)
        {
            if (data.NewImage != null)
            {
                if (product.ProductImages != null && product.ProductImages.Any())
                {
                    var oldImage = product.ProductImages.First();
                    string oldPath = _env.GenerateFilePath("img/products", oldImage.Name);
                    oldPath.DeleteFileFromLocal();

                    oldImage.Name = null; // Remove old image reference
                }

                string fileName = $"{Guid.NewGuid()}-{data.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("img/products", fileName);
                await data.NewImage.SaveFileToLocalAsync(newPath);

                if (product.ProductImages == null)
                {
                    product.ProductImages = new List<ProductImage>();
                }

                product.ProductImages.Add(new ProductImage
                {
                    Name = fileName,
                    IsMain = true
                });
            }

            product.Name = data.Name.Trim();
            product.Description = data.Description.Trim();
            product.Price = data.Price;
            product.ProductCode = data.ProductCode.Trim();
            product.SubcategoryId = data.SubCategoryId;
            product.SubSubCategoryId = data.SubSubCategoryId;

            await _context.SaveChangesAsync();
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

        public async Task<IEnumerable<Product>> GetAllPopularAsync()
        {
            // Define what makes a product popular, e.g., by sales or ratings
            return await _context.Products
                .Where(p => p.ProductImages.Any(img => img.IsMain))  // Example condition for popular products
                .Include(p => p.Subcategory)
                .Include(p => p.SubSubCategory)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }

        public async Task<SelectList> GetAllSelectedActiveAsync()
        {
            var products = await _context.Products
                .Where(p => p.ProductImages.Any(img => img.IsMain))
                .ToListAsync();

            return new SelectList(products, "Id", "Name");
        }

        public async Task<SelectList> GetAllSelectedAvailableAsync(int categoryId, int subCategoryId)
        {
            var products = await _context.Products
                .Where(p => p.SubcategoryId == subCategoryId &&
                            (p.SubSubCategoryId == null || p.SubSubCategoryId == categoryId))
                .ToListAsync();

            return new SelectList(products, "Id", "Name");
        }

        public IEnumerable<ProductVM> GetMappedDatas(IEnumerable<Product> products)
        {
            return products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages.FirstOrDefault(img => img.IsMain)?.Name,
                SubCategoryId = (int)p.SubcategoryId,
                SubCategoryName = p.Subcategory?.Name,
                SubSubCategoryId = p.SubSubCategoryId,
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

        public async Task<Product> GetByIdWithImagesAsync(int id)
        {
            return await _context.Products
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

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task DeleteProductImageAsync(MainAndDeleteImageVM data)
        {
            var image = await _context.ProductImages.FindAsync(data.ImageId);

            if (image != null)
            {
                string imagePath = _env.GenerateFilePath("img/products", image.Name);
                imagePath.DeleteFileFromLocal();

                _context.ProductImages.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetMainImageAsync(ProductVM data)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == data.Id);

            if (product != null)
            {
                // Set all images of the product to not main
                foreach (var image in product.ProductImages)
                {
                    image.IsMain = false;
                }

                // Set the specified image as main
                var mainImage = product.ProductImages.FirstOrDefault(i => i.Id == data.Id);
                if (mainImage != null)
                {
                    mainImage.IsMain = true;
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
