using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Contacts;

namespace StoneSafety.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetAllAsync();

            var response = contacts.Select(m => new ContactVM
            {
                Id = m.Id,
                Name = m.Name,
                SurName = m.SurName,
                Email = m.Email,
                Subject = m.Subject,
                Message = m.Message
            });

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var contact = await _contactService.GetByIdAsync((int)id);

            if (contact is null) return NotFound();

            await _contactService.DeleteAsync(contact);

            return Ok();
        }
    }
}
