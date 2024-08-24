using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoneSafety.Models;


namespace StoneSafety.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {             
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<About>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Banner>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<SubCategory>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<SubSubCategory>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Setting>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Contact>().HasQueryFilter(m => !m.SoftDeleted);

           
            builder.Entity<Product>()
                .HasOne(p => p.SubSubCategory)
                .WithMany(ssc => ssc.Products)
                .HasForeignKey(p => p.SubSubCategoryId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<Product>()
                .HasOne(p => p.Subcategory)
                .WithMany(sc => sc.Products)
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SubSubCategory>()
                .HasOne(ssc => ssc.SubCategory)
                .WithMany(sc => sc.SubSubCategories)
                .HasForeignKey(ssc => ssc.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

            builder.Entity<ProductImage>()
               .HasQueryFilter(pi => !pi.Product.SoftDeleted);




            base.OnModelCreating(builder);
        }
    }
}
