using StoneSafety.Models;
using StoneSafety.ViewModels.Settings;

namespace StoneSafety.Services.Interfaces
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();
        Task<IEnumerable<Setting>> GetAllListedAsync();
        Task<Setting> GetByIdAsync(int id);
        Task EditAsync(Setting setting, SettingEditVM data);
    }
}
