﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechSupportData;

namespace TechSupportData.Migrations
{
    [DbContext(typeof(TechSupportDbContext))]
    partial class TechSupportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TechSupportData.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProductTypeId");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Macbook Air 2018",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Macbook Pro 13\" 2015",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Macbook Pro 15' 2015",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "ThinkPad X1 Carbon",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 28,
                            Name = "ThinkPad T480",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 29,
                            Name = "ThinkPad T400",
                            ProductTypeId = 1
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "HP Pavilion Gaming 690-0007nc",
                            ProductTypeId = 2
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Acer Nitro GX50-600",
                            ProductTypeId = 2
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Counter Strike: Global Offensive",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 8,
                            Name = "Counter Strike 1.6",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 9,
                            Name = "Counter Strike: Source",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 10,
                            Name = "Sid Meier's Civilisation VI",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 11,
                            Name = "Sid Meier's Civilisation V",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 12,
                            Name = "Sid Meier's Civilisation IV",
                            ProductTypeId = 3
                        },
                        new
                        {
                            ProductId = 13,
                            Name = "iPhone 7",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 14,
                            Name = "iPhone 8",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 15,
                            Name = "iPhone X",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 16,
                            Name = "iPhone XR",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 17,
                            Name = "Samsung Galaxy S10",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 18,
                            Name = "Samsung Galaxy S9",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 19,
                            Name = "Samsung Galaxy S8",
                            ProductTypeId = 4
                        },
                        new
                        {
                            ProductId = 20,
                            Name = "55\" LG 55UK6470PLC",
                            ProductTypeId = 5
                        },
                        new
                        {
                            ProductId = 21,
                            Name = "55\" Sony Bravia KD-55XF8577",
                            ProductTypeId = 5
                        },
                        new
                        {
                            ProductId = 23,
                            Name = "Windows 10 Pro",
                            ProductTypeId = 6
                        },
                        new
                        {
                            ProductId = 24,
                            Name = "Windows 10 Home",
                            ProductTypeId = 6
                        },
                        new
                        {
                            ProductId = 25,
                            Name = "Windows 8 Home",
                            ProductTypeId = 6
                        },
                        new
                        {
                            ProductId = 26,
                            Name = "Windows 7 Pro",
                            ProductTypeId = 6
                        },
                        new
                        {
                            ProductId = 27,
                            Name = "Microsoft Office 365",
                            ProductTypeId = 6
                        });
                });

            modelBuilder.Entity("TechSupportData.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            ProductTypeId = 1,
                            Name = "Notebooks"
                        },
                        new
                        {
                            ProductTypeId = 2,
                            Name = "PCs"
                        },
                        new
                        {
                            ProductTypeId = 3,
                            Name = "Video Games"
                        },
                        new
                        {
                            ProductTypeId = 4,
                            Name = "Smart Phones"
                        },
                        new
                        {
                            ProductTypeId = 5,
                            Name = "TVs"
                        },
                        new
                        {
                            ProductTypeId = 6,
                            Name = "Software"
                        });
                });

            modelBuilder.Entity("TechSupportData.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentFileName");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("DateTimeCreated");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("ProductId");

                    b.HasKey("QuestionId");

                    b.HasIndex("AttachmentFileName")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TechSupportData.Models.Resolution", b =>
                {
                    b.Property<int>("ResultionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<string>("AttachmentFileName");

                    b.Property<DateTime>("DateTimeResolved");

                    b.Property<int>("QuestionId");

                    b.HasKey("ResultionId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("Resolutions");
                });

            modelBuilder.Entity("TechSupportData.Models.Product", b =>
                {
                    b.HasOne("TechSupportData.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TechSupportData.Models.Question", b =>
                {
                    b.HasOne("TechSupportData.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TechSupportData.Models.Resolution", b =>
                {
                    b.HasOne("TechSupportData.Models.Question", "Question")
                        .WithOne("Resolution")
                        .HasForeignKey("TechSupportData.Models.Resolution", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
