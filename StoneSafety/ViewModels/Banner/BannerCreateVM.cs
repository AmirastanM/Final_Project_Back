using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Banner
{
    public class BannerCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
