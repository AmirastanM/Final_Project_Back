using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StoneSafety.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public ICollection<SubCategoryVM> Subcategories { get; set; } = new List<SubCategoryVM>();
    }

    public class SubCategoryVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public ICollection<SubSubCategoryVM> SubSubCategories { get; set; } = new List<SubSubCategoryVM>();
    }

    public class SubSubCategoryVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
