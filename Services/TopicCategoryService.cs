using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TopicCategoryService : ITopicCategoryService
    {
        private readonly HttpClient _httpClient;
        public TopicCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(TopicCategory u)
        {
            await _httpClient.PostAsJsonAsync("api/TopicCategory", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/TopicCategory/{id}");
        }

        public async Task<TopicCategory> GetTopicCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<TopicCategory>($"api/TopicCategory/{id}");
        }

        public async Task<IEnumerable<TopicCategory>> GetTopicCategoryAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TopicCategory>>("api/TopicCategory");
        }

        public async Task Update(TopicCategory u)
        {
            await _httpClient.PutAsJsonAsync($"api/TopicCategory/{u.TopicCategoryId}", u);
        }
    }
}
