﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Beyaz Eşyalar Kategorisi gösterişli.",
                            Name = "Beyaz Eşya",
                            Status = false,
                            UpdatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Kirtasiye Kategorisi kullanışlı.",
                            Name = "Kirtasiye",
                            Status = false,
                            UpdatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Kullanışlı Doga Dostudur.",
                            Name = "Buzdolabı",
                            Status = false,
                            UpdatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "0.7 Uçlu kalem.",
                            Name = "Kalem",
                            Status = false,
                            UpdatedDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
