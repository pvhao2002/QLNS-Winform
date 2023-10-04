using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;
        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeDAO();
                return instance;
            }
        }
        private EmployeeDAO() { }


        public List<Employee> getEmployeeCanBeManager()
        {
            List<Employee> list = new List<Employee>();
            string sql = "SELECT e.*\r\nFROM employee e\r\nLEFT JOIN department d ON e.id = d.manager_id AND d.is_deleted = 0\r\nWHERE d.id IS NULL AND e.is_deleted = 0;";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Employee
                            {
                                id = Convert.ToInt32(reader["id"]),
                                fullName = reader["full_name"] != DBNull.Value ? reader["full_name"].ToString() : string.Empty,
                                address = reader["address"] != DBNull.Value ? reader["address"].ToString() : string.Empty,
                                birthday = reader["birthday"] != DBNull.Value ? Convert.ToDateTime(reader["birthday"]) : (DateTime?)null,
                                gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() : "N/A",
                                phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "N/A",
                                position = reader["position"] != DBNull.Value ? reader["position"].ToString() : "N/A",
                                departmentId = reader["department_id"] != DBNull.Value ? Convert.ToInt32(reader["department_id"].ToString()) : (int?)null,
                                isDeleted = Convert.ToBoolean(reader["is_deleted"].ToString()),
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void add(Employee employee)
        {
            string sql = "INSERT INTO employee(full_name, address, birthday, gender, phone, position, department_id) VALUES(@fullname, @address, @birthday, @gender, @phone, @position, @department);";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    var deptId = employee.departmentId == -1 ? DBNull.Value : (object)employee.departmentId;
                    cmd.Parameters.AddWithValue("@fullname", employee.fullName);
                    cmd.Parameters.AddWithValue("@address", employee.address);
                    cmd.Parameters.AddWithValue("@birthday", employee.birthday);
                    cmd.Parameters.AddWithValue("@gender", employee.gender);
                    cmd.Parameters.AddWithValue("@phone", employee.phone);
                    cmd.Parameters.AddWithValue("@position", employee.position);
                    cmd.Parameters.AddWithValue("@department", deptId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void update(Employee emp)
        {
            string sql = "UPDATE employee SET full_name = @fullname, address=@address, birthday=@birthday, gender=@gender, phone=@phone, position=@position, department_id=@dept WHERE id = @id";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    var deptId = emp.departmentId == -1 ? DBNull.Value : (object)emp.departmentId;
                    cmd.Parameters.AddWithValue("@fullname", emp.fullName);
                    cmd.Parameters.AddWithValue("@address", emp.address);
                    cmd.Parameters.AddWithValue("@birthday", emp.birthday);
                    cmd.Parameters.AddWithValue("@gender", emp.gender);
                    cmd.Parameters.AddWithValue("@phone", emp.phone);
                    cmd.Parameters.AddWithValue("@position", emp.position);
                    cmd.Parameters.AddWithValue("@dept", deptId);
                    cmd.Parameters.AddWithValue("@id", emp.id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void delete(int? empId)
        {
            string sql = "UPDATE employee SET is_deleted = 1 WHERE id = @id";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            string sql = $"SELECT e.id AS eid\r\n, e.full_name\r\n, e.address\r\n, e.birthday\r\n, e.gender\r\n, e.phone\r\n, e.position\r\n, e.department_id AS e_department_id\r\n, e.is_deleted AS e_is_deleted\r\n, d.id AS did\r\n, d.department_name\r\n, d.manager_id\r\n, d.description\r\n, d.is_deleted AS d_is_deleted\r\nFROM employee e \r\nINNER JOIN department d ON d.id = e.department_id\r\nWHERE e.is_deleted = 0 AND d.is_deleted = 0;";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Employee
                            {
                                id = Convert.ToInt32(reader["eid"]),
                                fullName = reader["full_name"] != DBNull.Value ? reader["full_name"].ToString() : string.Empty,
                                address = reader["address"] != DBNull.Value ? reader["address"].ToString() : string.Empty,
                                birthday = reader["birthday"] != DBNull.Value ? Convert.ToDateTime(reader["birthday"]) : (DateTime?)null,
                                gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() : "N/A",
                                phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "N/A",
                                position = reader["position"] != DBNull.Value ? reader["position"].ToString() : "N/A",
                                departmentId = reader["e_department_id"] != DBNull.Value ? Convert.ToInt32(reader["e_department_id"].ToString()) : (int?)null,
                                isDeleted = Convert.ToBoolean(reader["e_is_deleted"].ToString()),
                                department = new Department
                                {
                                    id = Convert.ToInt32(reader["did"]),
                                    departmentName = reader["department_name"] != DBNull.Value ? reader["department_name"].ToString() : string.Empty,
                                    managerId = reader["manager_id"] != DBNull.Value ? Convert.ToInt32(reader["manager_id"]) : (int?)null,
                                    description = reader["description"] != DBNull.Value ? reader["description"].ToString() : string.Empty,
                                    isDeleted = Convert.ToBoolean(reader["d_is_deleted"])
                                }
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
