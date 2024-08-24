using System.ComponentModel.DataAnnotations;

namespace StoneSafety.Models
{
    public class SubCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<SubSubCategory> SubSubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
