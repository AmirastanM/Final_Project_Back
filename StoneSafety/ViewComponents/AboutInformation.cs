using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;


namespace StoneSafety.ViewComponents
{
    public class AboutInformationViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IAboutService _aboutService;

        public AboutInformationViewComponent(ISettingService settingService, IAboutService aboutService)
        {
            _settingService = settingService;
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _aboutService.GetFirstAsync();
            var settings = await _settingService.GetAllAsync();

            return View(new AboutInformationVMVC
            {
                Title = about?.Title,
                Description = about?.Description,
                Settings = settings.ToDictionary(s => s.Key, s => s.Value)
                
            });
        }
    }



    public class AboutInformationVMVC
    {
        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<string> Abouts { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


    }
}