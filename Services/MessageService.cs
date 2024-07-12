using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Message u)
        {
            await _httpClient.PostAsJsonAsync("api/Message", u);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Message/{id}");
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Message>($"api/Message/{id}");
        }

        public async Task<IEnumerable<Message>> GetMessageAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Message>>("api/Message");
        }

        public async Task Update(Message u)
        {
            await _httpClient.PutAsJsonAsync($"api/Achievement/{u.MessageId}", u);
        }
    }
}
