using System.ComponentModel.DataAnnotations;

namespace StoneSafety.Models
{
    public class SubSubCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
