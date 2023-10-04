using DAO;
namespace BUS
{
    public class AccountBUS
    {
        private static AccountBUS _instance;
        public static AccountBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccountBUS();
                return _instance;
            }
        }
        private AccountBUS() { }
        public bool login(string username, string password)
        {
            return AccountDAO.Instance.login(username, password);
        }
    }
}
