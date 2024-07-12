using BusinessLogic.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public async Task Add(Message message)
        {
            await MessageDao.Instance.Add(message);
        }

        public async Task Delete(int id)
        {
            await MessageDao.Instance.Delete(id);
        }

        public async Task<IEnumerable<Message>> GetAllMessage()
        {
            return await MessageDao.Instance.GetMessageAll();
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await MessageDao.Instance.GetMessageById(id);
        }

        public async Task Update(Message message)
        {
            await MessageDao.Instance.Update(message);
        }
    }
}
