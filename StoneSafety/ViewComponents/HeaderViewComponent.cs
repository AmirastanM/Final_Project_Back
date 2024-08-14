using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;

namespace StoneSafety.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;

        public HeaderViewComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(new HeaderVMVC
            {
                Settings = await _settingService.GetAllAsync()
            }));
        }
    }

    public class HeaderVMVC
    {
        public Dictionary<string, string> Settings { get; set; }
    }
}
