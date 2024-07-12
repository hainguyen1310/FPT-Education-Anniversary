using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(News u)
        {
            await _httpClient.PostAsJsonAsync("api/News", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/News/{id}");
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<News>($"api/News/{id}");
        }

        public async Task<IEnumerable<News>> GetNewsAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<News>>("api/News");
        }

        public async Task Update(News u)
        {
            await _httpClient.PutAsJsonAsync($"api/News/{u.NewsId}", u);
        }
    }
}
