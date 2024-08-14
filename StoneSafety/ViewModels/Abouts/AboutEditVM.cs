using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Abouts
{
    public class AboutEditVM
    {
        [Required]  
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
