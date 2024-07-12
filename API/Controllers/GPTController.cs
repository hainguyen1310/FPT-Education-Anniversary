using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repositories;

public class GPTController : ControllerBase
{
    private static readonly HttpClient client = new HttpClient();
    private readonly IMessageRepository _messageRepository;
    private const string apiKey = "";
    private const string apiUrl = "https://api.openai.com/v1/chat/completions";

    public GPTController()
    {
        _messageRepository = new MessageRepository();
    }

    [HttpGet]
    [Route("UseChatGPT")]
    public async Task<IActionResult> UseChatGPT(string query)
    {
        var requestBody = new
        {
            model = "gpt-4o", // Hoặc sử dụng "gpt-4" nếu cần
            messages = new[]
            {
                new { role = "user", content = query }
            }
        };

        var requestJson = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.PostAsync(apiUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var responseObject = JsonConvert.DeserializeObject<ChatResponse>(responseString);
            var outputQuery = string.Join(" ", responseObject.choices.Select(c => c.message.content));
            return Ok(outputQuery);
        }
        else
        {
            return StatusCode((int)response.StatusCode, responseString);
        }
    }

    public class ChatResponse
    {
        public Choice[] choices { get; set; }
    }

    public class Choice
    {
        public Message message{ get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
