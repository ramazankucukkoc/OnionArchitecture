using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {

        }
        public Category(int id, string name) : this()
        {

            Id = id;
            Name = name;

        }

    }
}
