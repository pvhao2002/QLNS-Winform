using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RewardDiscipline
    {
        public int? id { get; set; }
        public int? employeeId { get; set; }
        public string type { get; set; }
        public DateTime? createAt { get; set; }
        public string description { get; set; }

        public virtual Employee employee { get; set; }
    }
}
