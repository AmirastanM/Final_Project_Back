using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Abouts
{
    public class AboutCreateVM
    {

        [Required]        
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
