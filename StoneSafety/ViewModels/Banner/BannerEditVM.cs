using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StoneSafety.ViewModels.Banner
{
    public class BannerEditVM
        
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
