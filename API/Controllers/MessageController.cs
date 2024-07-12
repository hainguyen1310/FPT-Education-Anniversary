using BusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;
using System.Net.Http.Headers;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private static readonly HttpClient client = new HttpClient();
        private const string apiKey = "";
        private const string apiUrl = "https://api.openai.com/v1/chat/completions";
        public MessageController()
        {
            _messageRepository = new MessageRepository();
        }
        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _messageRepository.GetAllMessage();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> Get(int id)
        {
            var message = await _messageRepository.GetMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            return message;
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Message message)
        {
            await _messageRepository.Add(message);
            return Content("Insert success!");
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Message message)
        {
            var temp = _messageRepository.GetMessageById(id);
            if (temp == null)
            {
                return NoContent();
            }
            message.MessageId = id;
            await _messageRepository.Update(message);
            return Content("Update success!");
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _messageRepository.GetMessageById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _messageRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
