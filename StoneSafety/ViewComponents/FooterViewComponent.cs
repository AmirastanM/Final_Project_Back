using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;

namespace StoneSafety.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;

        public FooterViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(new FooterVMVC
            {
                Settings = await _settingService.GetAllAsync()
            }));
        }
    }

    public class FooterVMVC
    {
        public Dictionary<string, string> Settings { get; set; }
    }
}
