using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AchievementService : IAchievementService
    {
        private readonly HttpClient _httpClient;
        public AchievementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Achievement u)
        {
            await _httpClient.PostAsJsonAsync("api/Achievement", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Achievement/{id}");
        }

        public async Task<Achievement> GetAchievementById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Achievement>($"api/Achievement/{id}");
        }

        public async Task<IEnumerable<Achievement>> GetAchievementAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Achievement>>("api/Achievement");
        }

        public async Task Update(Achievement u)
        {
            await _httpClient.PutAsJsonAsync($"api/Achievement/{u.AchievementId}", u);
        }
    }
}
