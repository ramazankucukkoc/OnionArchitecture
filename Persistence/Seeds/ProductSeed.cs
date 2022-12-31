using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Buzdolabı", Description = "Kullanışlı Doga Dostudur.",CategoryId=1 },
                new Product { Id = 2, Name = "Kalem", Description = "0.7 Uçlu kalem.",CategoryId=2 });
        }
    }
}
