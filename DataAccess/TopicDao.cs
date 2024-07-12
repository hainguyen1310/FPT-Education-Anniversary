using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TopicDao : SingletonBase<TopicDao>
    {
        public async Task<IEnumerable<Topic>> GetTopicAll()
        {
            return await _context.Topics.Include(c => c.TopicCategory).ToListAsync();
        }
        public async Task<Topic> GetTopicById(int id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(c => c.TopicId == id);
            if (topic == null) return null;
            return topic;
        }
        public async Task Add(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Topic topic)
        {
            var existingItem = await GetTopicById(topic.TopicId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(topic);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var topic = await GetTopicById(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Topic>> GetTopicByTitle(string name)
        {
            var topic = _context.Topics;
            return await topic.Where(u => u.TopicTitle.Contains(name)).ToListAsync();
        }
    }
}
