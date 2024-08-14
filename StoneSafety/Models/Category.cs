using System.ComponentModel.DataAnnotations;

namespace StoneSafety.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
