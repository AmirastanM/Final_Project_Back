using StoneSafety.Models;
using StoneSafety.ViewModels.Abouts;

namespace StoneSafety.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        Task<About> GetFirstAsync();
        Task CreateAsync(AboutCreateVM data);
        Task DeleteAsync(About about);
        Task EditAsync(About about, AboutEditVM data);
    }
}
