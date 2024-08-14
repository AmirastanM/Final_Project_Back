using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StoneSafety.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StoneSafety.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {             
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<SubSubCategory> SubSubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<About>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Subcategory>().HasQueryFilter(m => !m.SoftDeleted);
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

            builder.Entity<Subcategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(sc => sc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);




            base.OnModelCreating(builder);
        }
    }
}
