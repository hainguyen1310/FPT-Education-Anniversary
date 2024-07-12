using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAll();
        Task<User> GetUserById(int id);
        Task Create(User u);
        Task Update(User u);
        Task Delete(int id);
		Task<User> GetUserByUserNamePass(string username, string password);
		Task<IEnumerable<User>> GetUserByName(string name);
	}
}
