using StoneSafety.Models;
using StoneSafety.ViewModels.Contacts;

namespace StoneSafety.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateVM data);
        Task DeleteAsync(Contact contact);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);

    }
}
