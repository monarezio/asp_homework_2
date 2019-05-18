using System;
using Microsoft.EntityFrameworkCore;
using TechSupportData.Models;

namespace TechSupportData
{
    public class TechSupportDbContext : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }

        public TechSupportDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasIndex(i => i.AttachmentFileName)
                .IsUnique();
            
            //Adding test data to the db.
            ProductType[] productTypes =
            {
                new ProductType
                {
                    ProductTypeId = 1,
                    Name = "Notebooks"
                },
                new ProductType
                {
                    ProductTypeId = 2,
                    Name = "PCs"
                },
                new ProductType
                {
                    ProductTypeId = 3,
                    Name = "Video Games"
                },
                new ProductType
                {
                    ProductTypeId = 4,
                    Name = "Smart Phones"
                },
                new ProductType
                {
                    ProductTypeId = 5,
                    Name = "TVs"
                },
                new ProductType
                {
                    ProductTypeId = 6,
                    Name = "Software"
                },
            };
            modelBuilder.Entity<ProductType>().HasData(productTypes);
            Product[] products =
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Macbook Air 2018",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Macbook Pro 13\" 2015",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Macbook Pro 15' 2015",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 4,
                    Name = "ThinkPad X1 Carbon",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 28,
                    Name = "ThinkPad T480",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 29,
                    Name = "ThinkPad T400",
                    ProductTypeId = 1
                },
                new Product
                {
                    ProductId = 5,
                    Name = "HP Pavilion Gaming 690-0007nc",
                    ProductTypeId = 2
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Acer Nitro GX50-600",
                    ProductTypeId = 2
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Counter Strike: Global Offensive",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Counter Strike 1.6",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Counter Strike: Source",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Sid Meier's Civilisation VI",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Sid Meier's Civilisation V",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Sid Meier's Civilisation IV",
                    ProductTypeId = 3
                },
                new Product
                {
                    ProductId = 13,
                    Name = "iPhone 7",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 14,
                    Name = "iPhone 8",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 15,
                    Name = "iPhone X",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 16,
                    Name = "iPhone XR",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 17,
                    Name = "Samsung Galaxy S10",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 18,
                    Name = "Samsung Galaxy S9",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 19,
                    Name = "Samsung Galaxy S8",
                    ProductTypeId = 4
                },
                new Product
                {
                    ProductId = 20,
                    Name = "55\" LG 55UK6470PLC",
                    ProductTypeId = 5
                },
                new Product
                {
                    ProductId = 21,
                    Name = "55\" Sony Bravia KD-55XF8577",
                    ProductTypeId = 5
                },
                new Product
                {
                    ProductId = 23,
                    Name = "Windows 10 Pro",
                    ProductTypeId = 6
                },
                new Product
                {
                    ProductId = 24,
                    Name = "Windows 10 Home",
                    ProductTypeId = 6
                },
                new Product
                {
                    ProductId = 25,
                    Name = "Windows 8 Home",
                    ProductTypeId = 6
                },
                new Product
                {
                    ProductId = 26,
                    Name = "Windows 7 Pro",
                    ProductTypeId = 6
                },
                new Product
                {
                    ProductId = 27,
                    Name = "Microsoft Office 365",
                    ProductTypeId = 6
                },
            };
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}