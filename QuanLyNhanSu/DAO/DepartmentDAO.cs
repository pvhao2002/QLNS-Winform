using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DepartmentDAO
    {
        private static DepartmentDAO instance;
        public static DepartmentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DepartmentDAO();
                return instance;
            }
        }
        private DepartmentDAO() { }

        public void add(Department department)
        {
            string sql = $"INSERT INTO department(department_name, manager_id, description) VALUES(@name, @mnid, @desc);";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object mnID = department.managerId == -1 ? DBNull.Value : (object)department.managerId;
                    cmd.Parameters.AddWithValue("@name", department.departmentName);
                    cmd.Parameters.AddWithValue("@mnid", mnID);
                    cmd.Parameters.AddWithValue("@desc", department.description);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void update(Department department)
        {
            string sql = $"UPDATE department SET department_name = @name, manager_id=@mnid, description=@desc WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object mnID = department.managerId == -1 ? DBNull.Value : (object)department.managerId;
                    cmd.Parameters.AddWithValue("@name", department.departmentName);
                    cmd.Parameters.AddWithValue("@mnid", mnID);
                    cmd.Parameters.AddWithValue("@desc", department.description);
                    cmd.Parameters.AddWithValue("@id", department.id);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete(int id)
        {
            string sql = $"UPDATE department SET is_deleted = 1 WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void removeManager(int uid)
        {
            string sql = $"UPDATE department SET manager_id = NUll WHERE manager_id = @mnid";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mnid", uid);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void removeMangerByDid(int did)
        {
            string sql = $"UPDATE department SET manager_id = NUll WHERE id = @did";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@did", did);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public List<Department> getAll()
        {
            List<Department> list = new List<Department>();
            string sql = "SELECT d.*, e.id as eid, e.full_name, e.position FROM department d\r\nLEFT JOIN employee e ON d.manager_id = e.id AND e.is_deleted = 0 WHERE d.is_deleted = 0;";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Department
                            {
                                id = Convert.ToInt32(reader["id"]),
                                departmentName = reader["department_name"] != DBNull.Value ? reader["department_name"].ToString() : null,
                                managerId = reader["manager_id"] != DBNull.Value ? Convert.ToInt32(reader["manager_id"]) : (int?)null,
                                description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                isDeleted = reader["is_deleted"] != DBNull.Value && Convert.ToBoolean(reader["is_deleted"]),
                                manager = new Employee
                                {
                                    id = reader["eid"] != DBNull.Value ? Convert.ToInt32(reader["eid"]) : (int?)null,
                                    fullName = reader["full_name"].ToString(),
                                    position = reader["position"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return list;
        }

        public Department getById(int? id)
        {
            Department department = null;
            string sql = "SELECT * FROM department WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            department = new Department
                            {
                                id = Convert.ToInt32(reader["id"]),
                                departmentName = reader["department_name"] != DBNull.Value ? reader["department_name"].ToString() : null,
                                managerId = reader["manager_id"] != DBNull.Value ? Convert.ToInt32(reader["manager_id"]) : (int?)null,
                                description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                isDeleted = reader["is_deleted"] != DBNull.Value && Convert.ToBoolean(reader["is_deleted"])
                            };
                        }
                    }
                }
            }
            return department;
        }
    }
}
