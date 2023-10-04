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
    public class ContractDAO
    {
        private static ContractDAO instance;
        public static ContractDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ContractDAO();
                return instance;
            }
        }
        private ContractDAO() { }
        public void add(Contract item)
        {
            string sql = $"INSERT INTO contract(contract_type, start_date, end_date, salary, other_item, employee_id) VALUES(@ctype, @sdate, @edate, @salary, @other, @empid);";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object edate = item.endDate == null ? DBNull.Value : (object)item.endDate;
                    object empid = item.employeeId == null ? DBNull.Value : (object)(item.employeeId);
                    cmd.Parameters.AddWithValue("@ctype", item.contractType);
                    cmd.Parameters.AddWithValue("@sdate", item.startDate);
                    cmd.Parameters.AddWithValue("@edate", edate);
                    cmd.Parameters.AddWithValue("@salary", item.salary);
                    cmd.Parameters.AddWithValue("@other", item.otherItem);
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void update(Contract item)
        {
            string sql = "UPDATE contract SET contract_type=@ctype, start_date=@sdate, end_date=@edate, salary=@salary, other_item=@other, employee_id=@empid WHERE id = @id";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object edate = item.endDate == null ? DBNull.Value : (object)item.endDate;
                    object empid = item.employeeId == null ? DBNull.Value : (object)(item.employeeId);
                    cmd.Parameters.AddWithValue("@ctype", item.contractType);
                    cmd.Parameters.AddWithValue("@sdate", item.startDate);
                    cmd.Parameters.AddWithValue("@edate", edate);
                    cmd.Parameters.AddWithValue("@salary", item.salary);
                    cmd.Parameters.AddWithValue("@other", item.otherItem);
                    cmd.Parameters.AddWithValue("@empid", empid);
                    cmd.Parameters.AddWithValue("@id", item.id);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void delete(int id)
        {
            string sql = "DELETE FROM contract WHERE id = @id;";
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
        public void deleteByEmpId(int eid)
        {
            string sql = "DELETE FROM contract WHERE employee_id = @id;";
            using (SqlConnection conn = new SqlConnection(DBContext.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", eid);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Contract> getAll()
        {
            List<Contract> list = new List<Contract>();
            string sql = "SELECT c.*, e.id AS eid, e.full_name, e.position FROM contract c\r\nLEFT JOIN employee e ON e.id = c.employee_id AND e.is_deleted = 0;";
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
                            list.Add(new Contract
                            {
                                id = Convert.ToInt32(reader["id"]),
                                employeeId = reader["employee_id"] != DBNull.Value ? Convert.ToInt32(reader["employee_id"]) : (int?)null,
                                contractType = reader["contract_type"].ToString(),
                                startDate = Convert.ToDateTime(reader["start_date"]),
                                endDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : (DateTime?)null,
                                salary = Convert.ToDecimal(reader["salary"]),
                                otherItem = reader["other_item"].ToString(),
                                employee = new Employee
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
    }
}
