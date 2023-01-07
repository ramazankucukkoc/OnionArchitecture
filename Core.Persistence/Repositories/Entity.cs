namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public int Id { get; set; }

        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }

        public bool Status { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        public DateTime UpdatedDate { get; set; } = DateTime.Now.Date;



    }
}
