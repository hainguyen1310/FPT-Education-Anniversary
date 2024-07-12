using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TopicRepository : ITopicRepository
    {
        public async Task Add(Topic topic)
        {
           await TopicDao.Instance.Add(topic);
        }

        public async Task Delete(int id)
        {
            await TopicDao.Instance.Delete(id);
        }

        public async Task<IEnumerable<Topic>> GetAllTopic()
        {
            return await TopicDao.Instance.GetTopicAll();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await TopicDao.Instance.GetTopicById(id);
        }

        public async Task<IEnumerable<Topic>> GetTopicByTitle(string name)
        {
            return await TopicDao.Instance.GetTopicByTitle(name);
        }

        public async Task Update(Topic topic)
        {
            await TopicDao.Instance.Update(topic);
        }
    }
}
