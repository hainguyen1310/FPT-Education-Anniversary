using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FPTHistoryRepository : IFPTHistoryRepository
    {
        public async Task Add(FPTHistory fpthistory)
        {
           await FPTHistoryDao.Instance.Add(fpthistory);
        }

        public async Task Delete(int id)
        {
            await FPTHistoryDao.Instance.Delete(id);    
        }

        public async Task<IEnumerable<FPTHistory>> GetAllFPTHistory()
        {
            return await FPTHistoryDao.Instance.GetFPTHistoryAll();
        }

        public async Task<FPTHistory> GetFPTHistoryById(int id)
        {
            return await FPTHistoryDao.Instance.GetFPTHistoryById(id);
        }

        public async Task<IEnumerable<FPTHistory>> GetFPTHistoryByTitle(string name)
        {
            return await FPTHistoryDao.Instance.GetFPTHistoryByTitle(name);
        }

        public async Task Update(FPTHistory fpthistory)
        {
            await FPTHistoryDao.Instance.Update(fpthistory);
        }
    }
}
