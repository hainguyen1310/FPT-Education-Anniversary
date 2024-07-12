using AutoMapper;
using BusinessLogic.Model;
using FPTDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;
		private readonly IMapper _mapper;
		public TopicController(IMapper mapper)
        {
            _topicRepository = new TopicRepository();
            _mapper = mapper;
        }
        // GET: api/<TopicController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            var list = await _topicRepository.GetAllTopic();
            var listDTO = _mapper.Map<IEnumerable<TopicDTO>>(list);
			return Ok(listDTO);
        }

        // GET api/<TopicController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> Get(int id)
        {
            var topic = await _topicRepository.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return topic;
        }

        // GET api/<TopicController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopicByTitle(string name)
        {
            var topics = await _topicRepository.GetTopicByTitle(name);
            if (topics == null)
            {
                return NotFound();
            }
            return Ok(topics);
        }
        // POST api/<TopicController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Topic topic)
        {
            await _topicRepository.Add(topic);
            return Content("Insert success!");
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Topic topic)
        {
            var temp = _topicRepository.GetTopicById(id);
            if (temp == null)
            {
                return NoContent();
            }
            topic.TopicId = id;
            await _topicRepository.Update(topic);
            return Content("Update success!");
        }

        // DELETE api/<TopicController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _topicRepository.GetTopicById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _topicRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
