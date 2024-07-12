using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        public async Task Add(Achievement achievement)
        {
            await AchievementDao.Instance.Add(achievement);
        }

        public async Task Delete(int id)
        {
            await AchievementDao.Instance.Delete(id);
        }

        public async Task<Achievement> GetAchievementById(int id)
        {
            return await AchievementDao.Instance.GetAchievementById(id);
        }

        public async Task<IEnumerable<Achievement>> GetAchievementByTitle(string name)
        {
            return await AchievementDao.Instance.GetAchievementByTitle(name);
        }

        public async Task<IEnumerable<Achievement>> GetAllAchievement()
        {
            return await AchievementDao.Instance.GetAchievementAll();
        }

        public async Task Update(Achievement achievement)
        {
            await AchievementDao.Instance.Update(achievement);
        }
    }
}
