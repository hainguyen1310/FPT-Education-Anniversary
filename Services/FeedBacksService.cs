using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FeedBacksService : IFeedBacksService
    {
        private readonly HttpClient _httpClient;
        public FeedBacksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(FeedBacks u)
        {
            await _httpClient.PostAsJsonAsync("api/FeedBacks", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/FeedBacks/{id}");
        }

        public async Task<FeedBacks> GetFeedBacksById(int id)
        {
            return await _httpClient.GetFromJsonAsync<FeedBacks>($"api/FeedBacks/{id}");
        }

        public async Task<IEnumerable<FeedBacks>> GetFeedBacksAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FeedBacks>>("api/FeedBacks");
        }

        public async Task Update(FeedBacks u)
        {
            await _httpClient.PutAsJsonAsync($"api/FeedBacks/{u.UserId}/{u.BlogId}", u);
        }
    }
}
