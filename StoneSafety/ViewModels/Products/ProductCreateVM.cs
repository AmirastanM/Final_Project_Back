using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Products
{
    public class ProductCreateVM
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public IEnumerable<IFormFile> NewImages { get; set; }

        [Required]
        public int? SubCategoryId { get; set; }

        public int? SubSubCategoryId { get; set; }

        public IEnumerable<SelectListItem> SubCategories { get; set; }
        public IEnumerable<SelectListItem> SubSubCategories { get; set; }
    }
}
