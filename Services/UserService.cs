using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(User u)
        {
            await _httpClient.PostAsJsonAsync("api/User", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/User/{id}");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/User/{id}");
        }

		public async Task<IEnumerable<User>> GetUserByName(string name)
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<User>>($"api/User/{name}");
		}

		public async Task<User> GetUserByUserNamePass(string name, string pass)
		{
			return await _httpClient.GetFromJsonAsync<User>($"api/User/{name}/{pass}");
		}

		public async Task<IEnumerable<User>> GetUsersAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("api/User");
        }

        public async Task Update(User u)
        {
            await _httpClient.PutAsJsonAsync($"api/User/{u.UserId}", u);
        }
    }
}
