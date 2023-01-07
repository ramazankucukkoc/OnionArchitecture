using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Product()
        {

        }
        public Product(int id,int categoryId,string name,string description):this()
        {
            Id=id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }
    }
}
