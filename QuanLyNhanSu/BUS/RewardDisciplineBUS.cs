using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class RewardDisciplineBUS
    {
        private static RewardDisciplineBUS instance;
        public static RewardDisciplineBUS Instance
        {
            get
            {
                if(instance == null)
                    instance = new RewardDisciplineBUS();
                return instance;
            }
        }    
        private RewardDisciplineBUS() { }

        public List<RewardDiscipline> getAll()
        {
            return RewardDisciplineDAO.Instance.getAll();
        }
        public void deleteByEmployee(int eid)
        {
            RewardDisciplineDAO.Instance.deleteByEmployee(eid);
        }
        public void delete(int id)
        {
            RewardDisciplineDAO.Instance.delete(id);
        }

        public void update(RewardDiscipline item)
        {
            RewardDisciplineDAO.Instance.update(item);
        }
        public void add(RewardDiscipline item)
        {
            RewardDisciplineDAO.Instance.add(item);
        }
    }
}
