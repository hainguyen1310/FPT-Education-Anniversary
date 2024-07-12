using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDao : SingletonBase<UserDao>
    {
        public async Task<IEnumerable<User>> GetUserAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.UserId == id);
            if (user == null) return null;
            return user;
        }
        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(User user)
        {
            var existingItem = await GetUserById(user.UserId);
/*            var password = user.Password;
            if (string.IsNullOrEmpty(password))
            {
                user.Password = existingItem.Password;
            }*/
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByUserNamePass(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName.Equals(username) && u.Password.Equals(password));
            if (user == null) return null;

            return user;
        }

        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            return await _context.Users.Where(u => u.FullName.Contains(name)).ToListAsync();
        }
        

    }
}
