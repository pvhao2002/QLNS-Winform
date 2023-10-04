using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DepartmentBUS
    {
        private static DepartmentBUS instance;
        public static DepartmentBUS Instance
        {
            get
            {
                if(instance == null)
                    instance = new DepartmentBUS();
                return instance;
            }
        }
        private DepartmentBUS() { }
        public List<Department> getAll()
        {
            return DepartmentDAO.Instance.getAll();
        }
        public void add(Department department)
        {
            DepartmentDAO.Instance.add(department);
        }
        public void update(Department department)
        {
            DepartmentDAO.Instance.update(department);
        }
        public Department getById(int? id)
        {
            return DepartmentDAO.Instance.getById(id);
        }

        public void delete(int id)
        {
            DepartmentDAO.Instance.delete(id);
        }
        public void removeManager(int uid)
        {
            DepartmentDAO.Instance.removeManager(uid);
        }
        public void removeMangerByDid(int did)
        {
            DepartmentDAO.Instance.removeMangerByDid(did);
        }
    }
}
