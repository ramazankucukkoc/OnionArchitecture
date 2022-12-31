using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Status { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        public DateTime UpdatedDate { get; set; } = DateTime.Now.Date;



    }
}
