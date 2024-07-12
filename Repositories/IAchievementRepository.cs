using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAchievementRepository
    {
        Task<IEnumerable<Achievement>> GetAllAchievement();
        Task<Achievement> GetAchievementById(int id);
        Task Add(Achievement achievement);
        Task Update(Achievement achievement);
        Task Delete(int id);
        Task<IEnumerable<Achievement>> GetAchievementByTitle(string name);
    }
}
