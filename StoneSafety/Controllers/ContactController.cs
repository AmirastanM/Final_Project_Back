using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Contacts;

namespace StoneSafety.Controllers
{
      
        public class ContactController : Controller
        {
            private readonly ISettingService _settingService;
            private readonly IContactService _contactService;
            private readonly UserManager<AppUser> _userManager;

            public ContactController(
                ISettingService settingService,
                IContactService contactService,
                UserManager<AppUser> userManager)
            {
                _settingService = settingService;
                _contactService = contactService;
                _userManager = userManager;
            }

        public async Task<IActionResult> Index()
        {
         
            var settings = await _settingService.GetAllAsync();

          
            ViewBag.Email = settings.ContainsKey("Email") ? settings["Email"] : string.Empty;
            ViewBag.Phone = settings.ContainsKey("Phone") ? settings["Phone"] : string.Empty;
            ViewBag.Phone1 = settings.ContainsKey("Phone1") ? settings["Phone1"] : string.Empty;
            ViewBag.Location = settings.ContainsKey("Location") ? settings["Location"] : string.Empty;

           
            var response = new ContactCreateVM();

           
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                response.Email = user.Email;
            }

         
            return View(response);
        }



        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ContactCreateVM request)
            {
                var response = new ContactCreateVM();

                if (!ModelState.IsValid)
                {
                    ViewBag.settings = await _settingService.GetAllAsync();

                    if (User.Identity.IsAuthenticated)
                    {
                        var user = await _userManager.FindByNameAsync(User.Identity.Name);

                        response.Email = user.Email;
                    }

                    return View("Index", response);
                }

                await _contactService.CreateAsync(request);

                return RedirectToAction(nameof(Index));
            }
        }
    }

