using System.ComponentModel.DataAnnotations;

namespace StoneSafety.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required] 
        public string ProductCode { get; set; }
        public int Rating { get; set; }

        public int? SubSubCategoryId { get; set; }
        public SubSubCategory SubSubCategory { get; set; }
       
        public int? SubcategoryId { get; set; }
        public SubCategory Subcategory { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
