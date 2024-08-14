using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.SubSubCategories
{
    public class SubSubCategoryDetailVM
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(200, ErrorMessage = "Название не может превышать 200 символов.")]
        public string Name { get; set; } 

        public string SubCategoryName { get; set; } 

        public string CreatedDate { get; set; } 

        public string UpdatedDate { get; set; }
    }
}
