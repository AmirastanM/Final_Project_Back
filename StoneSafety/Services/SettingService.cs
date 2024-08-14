using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Settings;

namespace StoneSafety.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;

        public SettingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        public async Task<IEnumerable<Setting>> GetAllListedAsync()
        {
            return await _context.Settings
                .OrderByDescending(m => m.Id)
                .ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return await _context.Settings.FindAsync(id);
        }

        public async Task EditAsync(Setting setting, SettingEditVM data)
        {
            setting.Value = data.Value;
            setting.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
