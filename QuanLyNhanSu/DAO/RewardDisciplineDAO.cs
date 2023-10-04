using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DAO
{
    public class RewardDisciplineDAO
    {
        private static RewardDisciplineDAO instance;
        public static RewardDisciplineDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new RewardDisciplineDAO();
                return instance;
            }
        }
        private RewardDisciplineDAO() { }
        public void add(RewardDiscipline item)
        {
            string sql = "INSERT INTO rewards_discipline(type, create_at, description, employee_id) VALUES(@type, @createAt, @description, @empId);";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    var empId = item.employeeId == null ? DBNull.Value : (object)item.employeeId;
                    cmd.Parameters.AddWithValue("@type", item.type);
                    cmd.Parameters.AddWithValue("@createAt", item.createAt);
                    cmd.Parameters.AddWithValue("@description", item.description);
                    cmd.Parameters.AddWithValue("@empId", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void update(RewardDiscipline item)
        {
            string sql = "UPDATE rewards_discipline\r\nSET type = @type, create_at = @createAt, description = @desc, employee_id = @empId\r\nWHERE id = @id;";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    var empId = item.employeeId == null ? DBNull.Value : (object)item.employeeId;
                    cmd.Parameters.AddWithValue("@type", item.type);
                    cmd.Parameters.AddWithValue("@createAt", item.createAt);
                    cmd.Parameters.AddWithValue("@desc", item.description);
                    cmd.Parameters.AddWithValue("@empId", empId);
                    cmd.Parameters.AddWithValue("@id", item.id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete(int id)
        {
            string sql = "DELETE FROM rewards_discipline WHERE id = @id;";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteByEmployee(int eid)
        {
            string sql = "DELETE FROM rewards_discipline WHERE employee_id = @eid;";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@eid", eid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<RewardDiscipline> getAll()
        {
            List<RewardDiscipline> list = new List<RewardDiscipline>();
            string sql = " SELECT rd.*, e.full_name, e.position FROM rewards_discipline rd\r\n LEFT JOIN employee e ON rd.employee_id = e.id AND e.is_deleted = 0;";
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
                            list.Add(new RewardDiscipline
                            {
                                id = Convert.ToInt32(reader["id"]),
                                employeeId = reader["employee_id"] != DBNull.Value ? Convert.ToInt32(reader["employee_id"]):(int?)null,
                                type = reader["type"].ToString(),
                                createAt = reader["create_at"] != DBNull.Value ? Convert.ToDateTime(reader["create_at"]) : (DateTime?)null,
                                description = reader["description"].ToString(),
                                employee = new Employee
                                {
                                    id = reader["employee_id"] != DBNull.Value ? Convert.ToInt32(reader["employee_id"]) : (int?)null,
                                    fullName = reader["full_name"].ToString(),
                                    position = reader["position"].ToString(),
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
