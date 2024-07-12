using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FPTHistoryService : IFPTHistoryService
    {
        private readonly HttpClient _httpClient;
        public FPTHistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(FPTHistory u)
        {
            await _httpClient.PostAsJsonAsync("api/FPTHistory", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/FPTHistory/{id}");
        }

        public async Task<FPTHistory> GetFPTHistoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<FPTHistory>($"api/FPTHistory/{id}");
        }

        public async Task<IEnumerable<FPTHistory>> GetFPTHistoryAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FPTHistory>>("api/FPTHistory");
        }

        public async Task Update(FPTHistory u)
        {
            await _httpClient.PutAsJsonAsync($"api/Achievement/{u.FPTHistoryId}", u);
        }
    }
}
