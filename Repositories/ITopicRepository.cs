using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllTopic();
        Task<Topic> GetTopicById(int id);
        Task Add(Topic topic);
        Task Update(Topic topic);
        Task Delete(int id);
        Task<IEnumerable<Topic>> GetTopicByTitle(string name);
    }
}
