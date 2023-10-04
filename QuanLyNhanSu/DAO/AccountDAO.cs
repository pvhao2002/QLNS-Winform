using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }
        private AccountDAO() { }
        public bool login(string username, string password)
        {
            string sql = $"SELECT * FROM account WHERE username='{username}'";
            using (SqlConnection con = new SqlConnection(DBContext.connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string pass = reader["password"].ToString();
                            return !string.IsNullOrEmpty(pass) && pass.Equals(password);
                        }
                    }
                }

            }
            return false;
        }
    }
}
