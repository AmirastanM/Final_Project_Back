using StoneSafety.Models;
using StoneSafety.ViewModels.Banner;

namespace StoneSafety.Services.Interfaces
{
    public interface IBannerService
    {
        Task<IEnumerable<Banner>> GetAllAsync();
        Task<Banner> GetByIdAsync(int id);
        Task<Banner> GetFirstAsync();
        Task CreateAsync(BannerCreateVM data);
        Task DeleteAsync(Banner banner);
        Task EditAsync(Banner banner, BannerEditVM data);
    }
}

