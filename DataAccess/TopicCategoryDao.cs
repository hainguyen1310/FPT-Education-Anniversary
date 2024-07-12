using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TopicCategoryDao : SingletonBase<TopicCategoryDao>
    {
        public async Task<IEnumerable<TopicCategory>> GetTopicCategoryAll()
        {
            return await _context.TopicCategories.ToListAsync();
        }
        public async Task<TopicCategory> GetTopicCategoryById(int id)
        {
            var topicCategory = await _context.TopicCategories.FirstOrDefaultAsync(c => c.TopicCategoryId == id);
            if (topicCategory == null) return null;
            return topicCategory;
        }
        public async Task Add(TopicCategory topicCategory)
        {
            await _context.TopicCategories.AddAsync(topicCategory);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TopicCategory topicCategory)
        {
            var existingItem = await GetTopicCategoryById(topicCategory.TopicCategoryId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(topicCategory);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var topicCategory = await GetTopicCategoryById(id);
            if (topicCategory != null)
            {
                _context.TopicCategories.Remove(topicCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TopicCategory>> GetTopicCategoryByName(string name)
        {
            var topicCategory = _context.TopicCategories;
            return await topicCategory.Where(u => u.TopicName.Contains(name)).ToListAsync();
        }
    }
}
