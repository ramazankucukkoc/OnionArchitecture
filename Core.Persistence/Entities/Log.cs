using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; }
    }
}
