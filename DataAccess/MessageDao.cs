using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MessageDao : SingletonBase<MessageDao>
    {
        public async Task<IEnumerable<Message>> GetMessageAll()
        {
            return await _context.Messages.ToListAsync();
        }
        public async Task<Message> GetMessageById(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(c => c.MessageId == id);
            if (message == null) return null;
            return message;
        }
        public async Task Add(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Message message)
        {
            var existingItem = await GetMessageById(message.MessageId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(message);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var message = await GetMessageById(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }
    }
}
