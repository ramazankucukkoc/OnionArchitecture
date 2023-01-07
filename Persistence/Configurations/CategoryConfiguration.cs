﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(50);
            builder.ToTable("Category");
        }
    }
}
