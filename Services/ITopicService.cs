using BusinessLogic.Model;
using FPTDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicDTO>> GetTopicAll();
        Task<Topic> GetTopicById(int id);
        Task Create(Topic u);
        Task Update(Topic u);
        Task Delete(int id);
    }
}
