using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlog();
        Task<Blog> GetBlogById(int id);
        Task Add(Blog blog);
        Task Update(Blog blog);
        Task Delete(int id);
        Task<IEnumerable<Blog>> GetBlogByTitle(string name);
    }
}
