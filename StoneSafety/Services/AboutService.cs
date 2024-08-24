using Microsoft.EntityFrameworkCore;
using StoneSafety.Data;
using StoneSafety.Helpers.Extensions;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Abouts;

namespace StoneSafety.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutService(
            AppDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await _context.Abouts.ToListAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _context.Abouts.FindAsync(id);
        }

        public async Task<About> GetFirstAsync()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AboutCreateVM data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.Image.FileName}";

            string path = _env.GenerateFilePath("assets/images", fileName);

            await data.Image.SaveFileToLocalAsync(path);

            await _context.Abouts.AddAsync(new About
            {
                Title = data.Title.Trim(),
                Description = data.Description.Trim(),
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(About about)
        {
            string imagePath = _env.GenerateFilePath("assets/images", about.Image);
            imagePath.DeleteFileFromLocal();

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(About about, AboutEditVM data)
        {
            if (data.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("assets/images", about.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("assets/images", fileName);
                await data.NewImage.SaveFileToLocalAsync(newPath);

                about.Image = fileName;
            }

            about.Title = data.Title.Trim();
            about.Description = data.Description.Trim();
            about.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
