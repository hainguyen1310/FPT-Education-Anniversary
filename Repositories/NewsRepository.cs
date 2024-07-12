using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class NewsRepository : INewsRepository
    {
        public async Task Add(News achievement)
        {
            await NewsDao.Instance.Add(achievement);
        }

        public async Task Delete(int id)
        {
            await NewsDao.Instance.Delete(id);
        }

        public async Task<News> GetNewsById(int id)
        {
            return await NewsDao.Instance.GetNewsById(id);
        }

        public async Task<IEnumerable<News>> GetNewsByTitle(string name)
        {
            return await NewsDao.Instance.GetNewsByTitle(name);
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            return await NewsDao.Instance.GetNewsAll();
        }

        public async Task Update(News news)
        {
            await NewsDao.Instance.Update(news);
        }
    }
}
