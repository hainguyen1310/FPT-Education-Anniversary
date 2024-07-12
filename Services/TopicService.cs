using BusinessLogic.Model;
using FPTDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TopicService : ITopicService
    {
        private readonly HttpClient _httpClient;
        public TopicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Topic u)
        {
            await _httpClient.PostAsJsonAsync("api/Topic", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Topic/{id}");
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Topic>($"api/Topic/{id}");
        }

        public async Task<IEnumerable<TopicDTO>> GetTopicAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TopicDTO>>("api/Topic");
        }

        public async Task Update(Topic u)
        {
            await _httpClient.PutAsJsonAsync($"api/Topic/{u.TopicId}", u);
        }
    }
}
