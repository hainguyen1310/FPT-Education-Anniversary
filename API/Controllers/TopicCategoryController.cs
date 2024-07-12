using BusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicCategoryController : ControllerBase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;
        public TopicCategoryController()
        {
            _topicCategoryRepository = new TopicCategoryRepository();
        }
        // GET: api/<TopicCategoryController>
        [HttpGet]
        public async Task<IEnumerable<TopicCategory>> GetTopicCategories()
        {
            var list = await _topicCategoryRepository.GetAllTopicCategory();
            return list;
        }

        // GET api/<TopicCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicCategory>> Get(int id)
        {
            var topicCategory = await _topicCategoryRepository.GetTopicCategoryById(id);
            if (topicCategory == null)
            {
                return NotFound();
            }
            return topicCategory;
        }

        // GET api/<TopicCategoryController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<TopicCategory>>> GetTopicCategoryByName(string name)
        {
            var topicCategories = await _topicCategoryRepository.GetTopicCategoryByName(name);
            if (topicCategories == null)
            {
                return NotFound();
            }
            return Ok(topicCategories);
        }
        // POST api/<TopicCategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TopicCategory topicCategory)
        {
            await _topicCategoryRepository.Add(topicCategory);
            return Content("Insert success!");
        }

        // PUT api/<TopicCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TopicCategory topicCategory)
        {
            var temp = _topicCategoryRepository.GetTopicCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            topicCategory.TopicCategoryId = id;
            await _topicCategoryRepository.Update(topicCategory);
            return Content("Update success!");
        }

        // DELETE api/<TopicCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _topicCategoryRepository.GetTopicCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _topicCategoryRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
