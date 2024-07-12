using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FeedBacksDao : SingletonBase<FeedBacksDao>
    {
        public async Task<IEnumerable<FeedBacks>> GetFeedBacksAll()
        {
            return await _context.FeedBacks.ToListAsync();
        }
        public async Task<IEnumerable<FeedBacks>> GetFeedBacksById(int id)
        {
            var feedbacks = await _context.FeedBacks.Where(c => c.UserId == id).ToListAsync();
            if (feedbacks == null) return null;

            return feedbacks;
        }
        public async Task<FeedBacks> GetFeedBacksByUserIdBlogId(int userId, int blogId)
        {
            var orderdetail = await _context.FeedBacks.FirstOrDefaultAsync(c => c.UserId == userId && c.BlogId == blogId);
            if (orderdetail == null) return null;

            return orderdetail;
        }
        public async Task Add(FeedBacks feedbacks)
        {
            await _context.FeedBacks.AddAsync(feedbacks);
            await _context.SaveChangesAsync();
        }
        public async Task Update(FeedBacks feedbacks)
        {
            var existingItem = await GetFeedBacksByUserIdBlogId(feedbacks.UserId, feedbacks.BlogId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(feedbacks);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int userId, int blogId)
        {
            var orderDetail = await GetFeedBacksByUserIdBlogId(userId, blogId);

            if (orderDetail != null)
            {
                _context.FeedBacks.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
