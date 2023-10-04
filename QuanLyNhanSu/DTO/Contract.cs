using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contract
    {
        public int? id { get; set; }
        public int? employeeId { get; set; }
        public string contractType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public decimal salary { get; set; }
        public string otherItem { get; set; }

        public virtual Employee employee { get; set; }
    }
}
