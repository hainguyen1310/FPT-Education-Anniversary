using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public async Task Add(Blog blog)
        {
            await BlogDao.Instance.Add(blog);   
        }

        public async Task Delete(int id)
        {
            await BlogDao.Instance.Delete(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlog()
        {
            return await BlogDao.Instance.GetBlogAll();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await BlogDao.Instance.GetBlogById(id);
        }

        public async Task<IEnumerable<Blog>> GetBlogByTitle(string name)
        {
            return await BlogDao.Instance.GetBlogByTitle(name);
        }

        public async Task Update(Blog blog)
        {
            await BlogDao.Instance.Update(blog);
        }
    }
}
