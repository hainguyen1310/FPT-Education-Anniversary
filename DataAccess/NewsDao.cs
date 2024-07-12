using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsDao : SingletonBase<NewsDao>
    {
        public async Task<IEnumerable<News>> GetNewsAll()
        {
            return await _context.News.ToListAsync();
        }
        public async Task<News> GetNewsById(int id)
        {
			return await _context.News.FirstOrDefaultAsync(c => c.NewsId == id);
		}
        public async Task Add(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
        }
        public async Task Update(News news)
        {
            var existingItem = await GetNewsById(news.NewsId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(news);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var achievement = await GetNewsById(id);
            if (achievement != null)
            {
                _context.News.Remove(achievement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<News>> GetNewsByTitle(string name)
        {
            var achievements = _context.News;
            return await achievements.Where(u => u.Title.Contains(name)).ToListAsync();
        }

    }
}
