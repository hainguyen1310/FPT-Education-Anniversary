using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFPTHistoryRepository
    {
        Task<IEnumerable<FPTHistory>> GetAllFPTHistory();
        Task<FPTHistory> GetFPTHistoryById(int id);
        Task Add(FPTHistory fpthistory);
        Task Update(FPTHistory fpthistory);
        Task Delete(int id);
        Task<IEnumerable<FPTHistory>> GetFPTHistoryByTitle(string name);
    }
}
