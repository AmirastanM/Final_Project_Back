using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.SubCategories
{
    public class SubCategoryCreateVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } 

        [Required]
        public int CategoryId { get; set; } 
       
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
