using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;

public class BannerViewComponent : ViewComponent
{
    private readonly IBannerService _bannerService;
  


    public BannerViewComponent(IBannerService bannerService)

    {
        _bannerService = bannerService;
        

    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var banner = await _bannerService.GetFirstAsync();
      



        return await Task.FromResult(View(new BannerVMVC
        {
            Title = banner.Title,
            Description = banner.Description,
            Image = banner.Image,
           
        }));
    }
}

public class BannerVMVC
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
   
}
