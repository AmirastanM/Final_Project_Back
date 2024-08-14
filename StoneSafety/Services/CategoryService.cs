using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Categories;
using StoneSafety.ViewModels.SubCategories;

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
                .Include(c => c.Subcategories)
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
                .Include(c => c.Subcategories)
                .FirstOrDefaultAsync();
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }

        public IEnumerable<CategoryVM> GetMappedDatas(IEnumerable<Category> categories)
        {
            return categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Subcategories = c.Subcategories.Select(sc => new SubCategoryVM
                {
                    Id = sc.Id,
                    Name = sc.Name
                }).ToList()
            });
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories
                .OrderByDescending(c => c.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(c => c.Subcategories)
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
            string path = _env.GenerateFilePath("img", fileName);

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
                string oldPath = _env.GenerateFilePath("img", category.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("img", fileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);

                category.Image = fileName;
            }

            category.Name = request.Name.Trim();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            string imagePath = _env.GenerateFilePath("img", category.Image);
            imagePath.DeleteFileFromLocal();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }


}
