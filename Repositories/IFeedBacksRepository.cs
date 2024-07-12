using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IFeedBacksRepository
    {
        Task<IEnumerable<FeedBacks>> GetAllFeedBacks();
        Task<FeedBacks> GetFeedBacksByUserIdBlogId(int userId, int blogId);
        Task Add(FeedBacks feedBacks);
        Task Update(FeedBacks feedBacks);
        Task Delete(int userId, int blogId);
        Task<IEnumerable<FeedBacks>> GetFeedBacksById(int id);
    }
}
