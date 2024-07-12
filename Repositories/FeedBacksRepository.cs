using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FeedBacksRepository : IFeedBacksRepository
    {
        public async Task Add(FeedBacks feedBacks)
        {
            await FeedBacksDao.Instance.Add(feedBacks);
        }

        public async Task Delete(int userId, int blogId)
        {
            await FeedBacksDao.Instance.Delete(userId, blogId); 
        }

        public async Task<IEnumerable<FeedBacks>> GetAllFeedBacks()
        {
            return await FeedBacksDao.Instance.GetFeedBacksAll();
        }

        public async Task<IEnumerable<FeedBacks>> GetFeedBacksById(int id)
        {
            return await FeedBacksDao.Instance.GetFeedBacksById(id);
        }

        public async Task<FeedBacks> GetFeedBacksByUserIdBlogId(int userId, int blogId)
        {
            return await FeedBacksDao.Instance.GetFeedBacksByUserIdBlogId(userId, blogId);
        }

        public async Task Update(FeedBacks feedBacks)
        {
            await FeedBacksDao.Instance.Update(feedBacks);
        }
    }
}
