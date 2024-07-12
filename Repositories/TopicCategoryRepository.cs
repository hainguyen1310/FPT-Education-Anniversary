using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TopicCategoryRepository : ITopicCategoryRepository
    {
        public async Task Add(TopicCategory topicCategory)
        {
            await TopicCategoryDao.Instance.Add(topicCategory);
        }

        public async Task Delete(int id)
        {
            await TopicCategoryDao.Instance.Delete(id);
        }

        public async Task<TopicCategory> GetTopicCategoryById(int id)
        {
            return await TopicCategoryDao.Instance.GetTopicCategoryById(id);
        }

        public async Task<IEnumerable<TopicCategory>> GetAllTopicCategory()
        {
            return await TopicCategoryDao.Instance.GetTopicCategoryAll();
        }

        public async Task<IEnumerable<TopicCategory>> GetTopicCategoryByName(string name)
        {
            return await TopicCategoryDao.Instance.GetTopicCategoryByName(name);
        }

        public async Task Update(TopicCategory topicCategory)
        {
            await TopicCategoryDao.Instance.Update(topicCategory);
        }
    }
}
