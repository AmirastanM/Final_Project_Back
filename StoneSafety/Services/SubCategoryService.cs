using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.ViewModels.SubCategories; 
using StoneSafety.ViewModels.SubSubCategories; 
using StoneSafety.ViewModels.Products;
using StoneSafety.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SubCategoryService : ISubCategoryService
{
    private readonly AppDbContext _context;

    public SubCategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistAsync(string name, int categoryId)
    {
        return await _context.SubCategories
            .AnyAsync(sc => sc.Name.Trim().ToLower() == name.Trim().ToLower() && sc.CategoryId == categoryId);
    }

    public async Task<int> CreateAsync(SubCategoryCreateVM subCategoryCreateVM)
    {
        var subCategory = new SubCategory
        {
            Name = subCategoryCreateVM.Name,
            CategoryId = subCategoryCreateVM.CategoryId
        };

        _context.SubCategories.Add(subCategory);
        await _context.SaveChangesAsync();

        return subCategory.Id;
    }

    public async Task<SubCategory> GetByIdAsync(int id)
    {
        return await _context.SubCategories
            .Include(sc => sc.Category)
            .Include(sc => sc.Products) 
            .Include(sc => sc.SubSubCategories) 
            .SingleOrDefaultAsync(sc => sc.Id == id);
    }


    public async Task UpdateAsync(SubCategory subCategory)
    {
        _context.SubCategories.Update(subCategory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        
        var subCategory = await _context.SubCategories
                                        .Include(sc => sc.SubSubCategories)
                                        .Include(sc => sc.Products)
                                        .FirstOrDefaultAsync(sc => sc.Id == id);

        if (subCategory == null)
        {
            throw new InvalidOperationException("SubCategory not found.");
        }

        _context.SubSubCategories.RemoveRange(subCategory.SubSubCategories);

      
        _context.Products.RemoveRange(subCategory.Products);

        
        _context.SubCategories.Remove(subCategory);

        await _context.SaveChangesAsync();
    }



    public async Task<IEnumerable<SubCategory>> GetAllWithHierarchyAsync()
    {
        return await _context.SubCategories
            .Include(sc => sc.SubSubCategories)
                .ThenInclude(ssc => ssc.Products)
            .ToListAsync();
    }

    public async Task<List<SubCategory>> GetAllPaginateAsync(int page, int take)
    {
        return await _context.SubCategories
            .OrderByDescending(c => c.Id)
            .Skip((page - 1) * take)
            .Take(take)
            .Include(sc => sc.SubSubCategories)
            .ThenInclude(scp => scp.Products)
            .ToListAsync();
    }


    


    public List<SubCategoryVM> GetMappedDatas(List<SubCategory> subCategories)
    {
        return subCategories.Select(sc => new SubCategoryVM
        {
            Id = sc.Id,
            Name = sc.Name,
            CreatedDate = sc.CreatedDate,
            SubSubCategories = sc.SubSubCategories?.Select(ssc => new SubSubCategoryVM
            {
                Id = ssc.Id,
                Name = ssc.Name,
                SubCategoryName = sc.Name,
                Products = ssc.Products?.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.ProductImages?.FirstOrDefault(pi => pi.IsMain)?.Name ?? string.Empty, 
                    Description = p.Description,
                    ProductCode = p.ProductCode,
                    Rating = p.Rating,
                    SubCategoryId = sc.Id,
                    SubCategoryName = sc.Name,
                    SubSubCategoryId = ssc.Id,
                    SubSubCategoryName = ssc.Name
                }).ToList() ?? new List<ProductVM>() 
            }).ToList() ?? new List<SubSubCategoryVM>(), 
            Products = sc.Products?.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.ProductImages?.FirstOrDefault(pi => pi.IsMain)?.Name ?? string.Empty, 
                Description = p.Description,
                ProductCode = p.ProductCode,
                Rating = p.Rating,
                SubCategoryId = sc.Id,
                SubCategoryName = sc.Name,
                SubSubCategoryId = null, 
                SubSubCategoryName = null 
            }).ToList() ?? new List<ProductVM>() 
        }).ToList() ?? new List<SubCategoryVM>(); 
    }




    public async Task<int> GetCountAsync()
    {
        return await _context.SubCategories.CountAsync();
    }

    public async Task<IEnumerable<SubCategory>> GetAllAsync()
    {
        return await _context.SubCategories
            .Include(sc => sc.SubSubCategories)
            .ThenInclude(ssc => ssc.Products)
            .ToListAsync();
    }

    public async Task<IEnumerable<SubSubCategory>> GetBySubCategoryIdAsync(int subCategoryId)
    {
        return await _context.SubSubCategories
            .Where(ssc => ssc.SubCategoryId == subCategoryId)
            .ToListAsync();
    }

    public async Task<int> GetProductCountBySubCategoryIdAsync(int subCategoryId)
    {
        return await _context.Products
            .Where(p => p.SubcategoryId == subCategoryId)
            .CountAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetAllSelectListAsync()
    {
        return await _context.SubCategories
            .Select(sc => new SelectListItem
            {
                Value = sc.Id.ToString(),
                Text = sc.Name
            })
            .ToListAsync();
    }
}

