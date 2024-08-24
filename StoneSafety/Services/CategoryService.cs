using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Categories;


namespace StoneSafety.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<Category>> GetAllWithHierarchyAsync()
        {
            return await _context.Categories
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.SubSubCategories)
                        .ThenInclude(ssc => ssc.Products)
                .Include(c => c.SubCategories)
                    .ThenInclude(sc => sc.Products)
                .ToListAsync();
        }


        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FindAsync(id);
        }

        public async Task<Category> GetByIdWithHierarchyAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllSelectListItemsAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
        }



        public IEnumerable<CategorySubCategoryVM> GetMappedDatas(IEnumerable<Category> categories)
        {
            return categories.Select(c => new CategorySubCategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Subcategories = c.SubCategories.Select(sc => new ViewModels.Categories.SubCategoryVM
                {
                    Name = sc.Name
                }).Cast<ViewModels.Categories.SubCategoryVM>().ToList() 
            });
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories
                .OrderByDescending(c => c.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(c => c.SubCategories)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task CreateAsync(CategoryCreateVM request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.Image.FileName}";
            string path = _env.GenerateFilePath("assets/images", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            var category = new Category
            {
                Name = request.Name.Trim(),
                Image = fileName
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Category category, CategoryEditVM request)
        {
            if (request.NewImage != null)
            {
             
                string oldPath = Path.Combine(_env.WebRootPath, "assets/images", category.Image); 
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

              
                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string newPath = Path.Combine(_env.WebRootPath, "assets/images", fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await request.NewImage.CopyToAsync(stream);
                }

                category.Image = fileName;
            }

         
            category.Name = request.Name.Trim();

            
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Category category)
        {
            string imagePath = _env.GenerateFilePath("assets/images", category.Image);
            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }



    }


}
