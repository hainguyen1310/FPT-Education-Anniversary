using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFeedBacksService
    {
        Task<IEnumerable<FeedBacks>> GetFeedBacksAll();
        Task<FeedBacks> GetFeedBacksById(int id);
        Task Create(FeedBacks u);
        Task Update(FeedBacks u);
        Task Delete(int id);
    }
}
