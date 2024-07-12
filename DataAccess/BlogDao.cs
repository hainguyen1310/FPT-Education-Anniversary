using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BlogDao : SingletonBase<BlogDao>
    {
        public async Task<IEnumerable<Blog>> GetBlogAll()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<Blog> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(c => c.BlogId == id);
            if (blog == null) return null;
            return blog;
        }
        public async Task Add(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Blog blog)
        {
            var existingItem = await GetBlogById(blog.BlogId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(blog);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var blog = await GetBlogById(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Blog>> GetBlogByTitle(string name)
        {
            var blog = _context.Blogs;
            return await blog.Where(u => u.Title.Contains(name)).ToListAsync();
        }
    }
}
