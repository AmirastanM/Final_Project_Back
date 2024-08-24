using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Banner;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerservice;
        private readonly IWebHostEnvironment _env;

        public BannerController(IBannerService bannerService, 
                                IWebHostEnvironment env)
        {
            _bannerservice = bannerService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var banners = await _bannerservice.GetAllAsync();

            
            var model = banners.Select(m => new BannerVM
            {
                Id = m.Id,
                Title = m.Title,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy"),
                Image = m.Image
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(BannerCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }
                       

            await _bannerservice.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var banner = await _bannerservice.GetByIdAsync((int)id);

            if (banner is null) return NotFound();

            await _bannerservice.DeleteAsync(banner);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var banner = await _bannerservice.GetByIdAsync((int)id);

            if (banner is null) return NotFound();

            var model = new BannerEditVM
            {
                Title = banner.Title,
                Description = banner.Description,
                Image = banner.Image
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BannerEditVM request)
        {
            if (id is null) return BadRequest();

            var banner = await _bannerservice.GetByIdAsync((int)id);
            if (banner is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = banner.Image; 
                return View(request);
            }

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Input can accept only image format");
                    request.Image = banner.Image; 
                    return View(request);
                }




                string oldPath = _env.GenerateFilePath("assets/images", banner.Image);
                oldPath.DeleteFileFromLocal();



                string fileName = $"{Guid.NewGuid()}-{request.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("assets/images", fileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);

              
                banner.Image = fileName;
            }

            
            banner.Title = request.Title.Trim();
            banner.Description = request.Description.Trim();
            banner.UpdatedDate = DateTime.Now;

          
            await _bannerservice.EditAsync(banner, request);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var banner = await _bannerservice.GetByIdAsync((int)id);

            if (banner is null) return NotFound();

            return View(new BannerDetailVM
            {
                Title = banner.Title,
                Description = banner.Description,
                Image = banner.Image,
                CreatedDate = banner.CreatedDate.ToString("MM.dd.yyyy"),
                UpdatedDate = banner.UpdatedDate != null ? banner.UpdatedDate.Value.ToString("MM.dd.yyyy") : "N/A"
            });
        }
    }
}
