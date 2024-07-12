using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task Add(News news);
        Task Update(News news);
        Task Delete(int id);
        Task<IEnumerable<News>> GetNewsByTitle(string name);
    }
}
