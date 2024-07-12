using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITopicCategoryRepository
    {
        Task<IEnumerable<TopicCategory>> GetAllTopicCategory();
        Task<TopicCategory> GetTopicCategoryById(int id);
        Task Add(TopicCategory topicCategory);
        Task Update(TopicCategory topicCategory);
        Task Delete(int id);
        Task<IEnumerable<TopicCategory>> GetTopicCategoryByName(string name);
    }
}
