using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFPTHistoryService
    {
        Task<IEnumerable<FPTHistory>> GetFPTHistoryAll();
        Task<FPTHistory> GetFPTHistoryById(int id);
        Task Create(FPTHistory u);
        Task Update(FPTHistory u);
        Task Delete(int id);
    }
}
