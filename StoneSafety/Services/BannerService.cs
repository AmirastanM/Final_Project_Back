using StoneSafety.Data;
using StoneSafety.Models;
using StoneSafety.Services.Interfaces;
using StoneSafety.ViewModels.Banner;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Helpers.Extensions;


namespace StoneSafety.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BannerService(
            AppDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<Banner>> GetAllAsync()
        {
            return await _context.Banners.ToListAsync();
        }

        public async Task<Banner> GetByIdAsync(int id)
        {
            return await _context.Banners.FindAsync(id);
        }

        public async Task<Banner> GetFirstAsync()
        {
            return await _context.Banners.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(BannerCreateVM data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.Image.FileName}";

            string path = _env.GenerateFilePath("assets/images", fileName);

            await data.Image.SaveFileToLocalAsync(path);

            await _context.Banners.AddAsync(new Banner
            {
                Title = data.Title.Trim(),
                Description = data.Description.Trim(),
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Banner banner)
        {
            string imagePath = _env.GenerateFilePath("assets/images", banner.Image);
            imagePath.DeleteFileFromLocal();

            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
        }


        public async Task EditAsync(Banner banner, BannerEditVM data)
        {
            if (data.NewImage != null)
            {
                string oldPath = _env.GenerateFilePath("assets/images", banner.Image);
                oldPath.DeleteFileFromLocal();

                string fileName = $"{Guid.NewGuid()}-{data.NewImage.FileName}";
                string newPath = _env.GenerateFilePath("assets/images", fileName);
                await data.NewImage.SaveFileToLocalAsync(newPath);

                banner.Image = fileName;
            }

            banner.Title = data.Title.Trim();
            banner.Description = data.Description.Trim();
            banner.UpdatedDate = DateTime.Now;

            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();
        }


    }
}
