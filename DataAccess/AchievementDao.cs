using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AchievementDao : SingletonBase<AchievementDao>
    {
        public async Task<IEnumerable<Achievement>> GetAchievementAll()
        {
            return await _context.Achievements.ToListAsync();
        }
        public async Task<Achievement> GetAchievementById(int id)
        {
			return await _context.Achievements.FirstOrDefaultAsync(c => c.AchievementId == id);
		}
        public async Task Add(Achievement achievement)
        {
            await _context.Achievements.AddAsync(achievement);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Achievement achievement)
        {
            var existingItem = await GetAchievementById(achievement.AchievementId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(achievement);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var achievement = await GetAchievementById(id);
            if (achievement != null)
            {
                _context.Achievements.Remove(achievement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Achievement>> GetAchievementByTitle(string name)
        {
            var achievements = _context.Achievements;
            return await achievements.Where(u => u.AchievementTitle.Contains(name)).ToListAsync();
        }

    }
}
