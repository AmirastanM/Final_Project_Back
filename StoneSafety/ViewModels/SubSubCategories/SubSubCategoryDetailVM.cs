using StoneSafety.ViewModels.Products;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryDetailVM
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(200, ErrorMessage = "The name cannot exceed 200 characters.")]
        public string Name { get; set; } 

        public string SubCategoryName { get; set; } 

        public string CreatedDate { get; set; } 

        public string UpdatedDate { get; set; }
        public int ProductCount { get; set; }
        public IEnumerable<ProductVM> Products { get; set; } 
        public IEnumerable<SubSubCategoryVM> SubSubCategories { get; set; }
    }
}
