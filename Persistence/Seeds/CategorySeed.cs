using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Beyaz Eşya", Description = "Beyaz Eşyalar Kategorisi gösterişli." },
                new Category { Id = 2, Name = "Kirtasiye", Description = "Kirtasiye Kategorisi kullanışlı." }
                );

        }
    }
}
