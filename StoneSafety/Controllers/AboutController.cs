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
            // Retrieve the first About record
            var about = await _aboutService.GetFirstAsync();
            if (about == null) return NotFound();

            // Retrieve settings as a dictionary
            var settings = await _settingService.GetAllAsync();

            // Map the About model to AboutVM
            var aboutVM = new AboutVM
            {
                Id = about.Id,
                Title = about.Title,
                Image = about.Image,
                CreatedDate = about.CreatedDate.ToString("MMMM dd, yyyy")
            };

            // Creating a view model with both AboutVM and settings
            var viewModel = new AboutIndexVM
            {
                About = aboutVM,
                Settings = settings
            };

            return View(viewModel);
        }
    }
}
