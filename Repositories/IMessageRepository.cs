using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllMessage();
        Task<Message> GetMessageById(int id);
        Task Add(Message message);
        Task Update(Message message);
        Task Delete(int id);
    }
}
