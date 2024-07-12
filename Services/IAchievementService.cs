using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<Achievement>> GetAchievementAll();
        Task<Achievement> GetAchievementById(int id);
        Task Create(Achievement u);
        Task Update(Achievement u);
        Task Delete(int id);
    }
}
