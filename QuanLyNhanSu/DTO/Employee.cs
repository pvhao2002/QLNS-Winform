using System;

namespace DTO
{
    public class Employee
    {
        public int? id { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public DateTime? birthday { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public int? departmentId { get; set; }
        public string position { get; set; }
        public bool isDeleted { get; set; }


        public string fullNamePosition => $"{fullName} - {position}";

        public string isDeleteDisplay => isDeleted ? "Đã bị xóa" : "Chưa bị xóa";

        public virtual Department department { get; set; }
    }
}
