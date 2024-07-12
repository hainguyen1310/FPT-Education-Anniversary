using BusinessLogic.Model;
using FPTDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetBlogAll();
        Task<Blog> GetBlogById(int id);
        Task Create(Blog u);
        Task Update(Blog u);
        Task Delete(int id);
    }
}
