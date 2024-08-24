using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;

namespace StoneSafety.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly ISettingService _settingService;


        public AboutViewComponent(IAboutService aboutService,ISettingService settingService)
          
        {
            _aboutService = aboutService;
            _settingService = settingService;
           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

           var about = await _aboutService.GetFirstAsync();
           var settings=await _settingService.GetAllAsync();



            return await Task.FromResult(View(new AboutVMVC
            {
                Title = about.Title,
                Description = about.Description,
                Image = about.Image,
                Settings = settings
            })) ;
        }
    }

    public class AboutVMVC
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Dictionary<string,string> Settings { get; set; }
    }
}
