using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;

namespace StoneSafety.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;


        public AboutViewComponent(IAboutService aboutService)
          
        {
            _aboutService = aboutService;
           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var about = await _aboutService.GetFirstAsync();
           



            return await Task.FromResult(View(new AboutVMVC
            {
                Title = about.Title,
                Description = about.Description,
                Image = about.Image               
            }));
        }
    }

    public class AboutVMVC
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }       
    }
}
