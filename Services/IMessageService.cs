using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessageAll();
        Task<Message> GetMessageById(int id);
        Task Create(Message u);
        Task Update(Message u);
        Task Delete(int id);
    }
}
