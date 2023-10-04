using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ContractBUS
    {
        private static ContractBUS instance;
        public static ContractBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ContractBUS();
                return instance;
            }
        }
        private ContractBUS() { }
        public List<Contract> getAll()
        {
            return ContractDAO.Instance.getAll();
        }

        public void delete(int id)
        {
            ContractDAO.Instance.delete(id);
        }

        public void update(Contract item)
        {
            ContractDAO.Instance.update(item);
        }
        public void add(Contract item)
        {
            ContractDAO.Instance.add(item);
        }
        public void deleteByEmpId(int eid)
        {
            ContractDAO.Instance.deleteByEmpId(eid);
        }
    }
}
