using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Abouts;
using StoneSafety.ViewModels.Settings;
using System.Threading.Tasks;

namespace StoneSafety.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ISettingService _settingService;

        public AboutController(IAboutService aboutService, ISettingService settingService)
        {
            _aboutService = aboutService;
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {

            var about = await _aboutService.GetFirstAsync();
            if (about == null) return NotFound();

          
            var settings = await _settingService.GetAllAsync();

        
            var aboutVM = new AboutVM
            {
                Id = about.Id,
                Title = about.Title,
                Image = about.Image,
                CreatedDate = about.CreatedDate.ToString("MMMM dd, yyyy")
            };

         
            var viewModel = new AboutIndexVM
            {
                About = aboutVM,
                Settings = settings
            };

            return View(viewModel);
        }
    }
}
