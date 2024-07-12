using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetNewsAll();
        Task<News> GetNewsById(int id);
        Task Create(News u);
        Task Update(News u);
        Task Delete(int id);
    }
}
