using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Department
    {
        public int id { get; set; }
        public string departmentName { get; set; }
        public int? managerId { get; set; }
        public string description { get; set; }
        public bool isDeleted { get; set; }

        public virtual Employee manager { get; set; }
        public virtual ICollection<Employee> employees { get; set; }

        public string isDeleteDisplay => isDeleted ? "Đã bị xóa" : "Chưa bị xóa";
    }
}
