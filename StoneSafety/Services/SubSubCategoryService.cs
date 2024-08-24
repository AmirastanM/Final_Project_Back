using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.ViewModels.Products;
using StoneSafety.ViewModels.SubSubCategories;


public class SubSubCategoryService : ISubSubCategoryService
{
    private readonly AppDbContext _context;

    public SubSubCategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistAsync(string name, int subCategoryId, int? excludeId = null)
    {
        return await _context.SubSubCategories
            .AnyAsync(ssc => ssc.Name.Trim().ToLower() == name.Trim().ToLower()
                && ssc.SubCategoryId == subCategoryId
                && (!excludeId.HasValue || ssc.Id != excludeId.Value));
    }

    public async Task<SubSubCategory> GetByIdAsync(int id)
    {
        return await _context.SubSubCategories
            .Include(ssc => ssc.SubCategory) 
            .Include(ssc => ssc.Products) 
            .FirstOrDefaultAsync(ssc => ssc.Id == id);
    }

    public async Task<int> CreateAsync(SubSubCategoryCreateVM request)
    {
      
        var subCategoryExists = await _context.SubCategories.AnyAsync(sc => sc.Id == request.SubCategoryId);
        if (!subCategoryExists)
        {
            throw new ArgumentException("Invalid SubCategoryId.");
        }

     
        var exists = await ExistAsync(request.Name, request.SubCategoryId);
        if (exists)
        {
            throw new InvalidOperationException("A SubSubCategory with this name already exists in the selected SubCategory.");
        }

        
        var subSubCategory = new SubSubCategory
        {
            Name = request.Name,
            SubCategoryId = request.SubCategoryId
        };

       
        _context.SubSubCategories.Add(subSubCategory);

       
        await _context.SaveChangesAsync();

      
        return subSubCategory.Id;
    }


    public async Task UpdateAsync(SubSubCategoryEditVM request)
    {
        var subSubCategory = await _context.SubSubCategories.FindAsync(request.Id);

        if (subSubCategory == null)
        {
            throw new KeyNotFoundException("Sub-subcategory not found");
        }

        
        subSubCategory.Name = request.Name;
        subSubCategory.SubCategoryId = request.SubCategoryId;

        _context.SubSubCategories.Update(subSubCategory);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(int id)
    {
        var subSubCategory = await _context.SubSubCategories.FindAsync(id);

        if (subSubCategory == null)
        {
            throw new KeyNotFoundException("Sub-subcategory not found");
        }

        _context.SubSubCategories.Remove(subSubCategory);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SubSubCategory>> GetAllAsync()
    {
        return await _context.SubSubCategories.Include(m => m.Products).Include(n => n.SubCategory).ToListAsync();
    }



    public async Task<List<SubSubCategoryVM>> GetPaginatedAsync(int page, int take)
    {
       
        var totalCount = await _context.SubSubCategories.CountAsync();

     
        var subSubCategories = await _context.SubSubCategories
            .Include(ssc => ssc.SubCategory)
            .Include(ssc => ssc.Products) 
            .OrderBy(ssc => ssc.Name)
            .Skip((page - 1) * take)
            .Take(take)
            .Select(ssc => new SubSubCategoryVM
            {
                Id = ssc.Id,
                Name = ssc.Name,
                SubCategoryName = ssc.SubCategory.Name,
                CreatedDate = ssc.CreatedDate,
                Products = ssc.Products.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    
                }).ToList(),
                ProductCount = ssc.Products.Count() 
            })
            .ToListAsync();

      
        return subSubCategories;
    }


  
    public async Task<int> GetCountAsync()
    {
        return await _context.SubCategories.CountAsync();
    }

    public async Task<IEnumerable<SubSubCategory>> GetBySubCategoryIdAsync(int subCategoryId)
    {
        return await _context.SubSubCategories
            .Where(ssc => ssc.SubCategoryId == subCategoryId)
            .ToListAsync();
    }
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.SubSubCategories.CountAsync();
    }




}

