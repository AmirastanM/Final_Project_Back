using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Contacts;

namespace StoneSafety.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ContactCreateVM data)
        {
            await _context.Contacts.AddAsync(new Contact
            {
                Name = data.Name,
                SurName = data.SurName,
                Email = data.Email,
                Subject = data.Subject,
                Message = data.Message
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts
                .OrderByDescending(m => m.Id)
                .ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}
