using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITopicCategoryService
    {
        Task<IEnumerable<TopicCategory>> GetTopicCategoryAll();
        Task<TopicCategory> GetTopicCategoryById(int id);
        Task Create(TopicCategory u);
        Task Update(TopicCategory u);
        Task Delete(int id);
    }
}
