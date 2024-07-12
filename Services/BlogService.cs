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
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Blog u)
        {
            await _httpClient.PostAsJsonAsync("api/Blog", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Blog/{id}");
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Blog>($"api/Blog/{id}");
        }

        public async Task<IEnumerable<Blog>> GetBlogAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Blog>>("api/Blog");
        }

        public async Task Update(Blog u)
        {
            await _httpClient.PutAsJsonAsync($"api/Blog/{u.BlogId}", u);
        }
    }
}
