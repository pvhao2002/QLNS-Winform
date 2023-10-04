using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class EmployeeBUS
    {
        private static EmployeeBUS instance;
        public static EmployeeBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeBUS();
                return instance;
            }
        }    
        private EmployeeBUS() { }
        public List<Employee> GetAll()
        {
            return EmployeeDAO.Instance.GetAll();
        }

        public void add(Employee employee)
        {
            EmployeeDAO.Instance.add(employee);
        }
        public void update(Employee employee)
        {
            EmployeeDAO.Instance.update(employee);
        }

        public void delete(int? id)
        {
            EmployeeDAO.Instance.delete(id);
        }

        public List<Employee> getEmployeeCanBeManager()
        {
            return EmployeeDAO.Instance.getEmployeeCanBeManager();
        }
    }
}
