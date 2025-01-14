﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Abouts;

namespace StoneSafety.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();

            return View(abouts.Select(m => new AboutVM
            {
                Id = m.Id,
                Title = m.Title,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy"),
                Image = m.Image
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(AboutCreateVM request)
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

         
            await _aboutService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            await _aboutService.DeleteAsync(about);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            return View(new AboutEditVM
            {
                Title = about.Title,
                Description = about.Description,
                Image = about.Image
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AboutEditVM request)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = about.Image;
                return View(request);
            }

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Input can accept only image format");
                    request.Image = about.Image;
                    return View(request);
                }

            }

            await _aboutService.EditAsync(about, request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            return View(new AboutDetailVM
            {
                Title = about.Title,
                Description = about.Description,
                Image = about.Image,
                CreatedDate = about.CreatedDate.ToString("MM.dd.yyyy"),
                UpdatedDate = about.UpdatedDate != null ? about.UpdatedDate.Value.ToString("MM.dd.yyyy") : "N/A"
            });
        }
    }
}
