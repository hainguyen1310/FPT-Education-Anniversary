using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        public NewsController()
        {
            _newsRepository = new NewsRepository();
        }
        // GET: api/<AchievementController>
        [HttpGet]
        public async Task<IEnumerable<News>> GetNews()
        {
            var list = await _newsRepository.GetAllNews();
            return list;
        }

        // GET api/<AchievementController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> Get(int id)
        {
            var achievement = await _newsRepository.GetNewsById(id);
            if (achievement == null)
            {
                return NotFound();
            }
            return achievement;
        }
        // GET api/<AchievementController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsByTitle(string name)
        {
            var achievement = await _newsRepository.GetNewsByTitle(name);
            if (achievement == null)
            {
                return NotFound();
            }
            return Ok(achievement);
        }

        // POST api/<AchievementController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] News news)
        {
            await _newsRepository.Add(news);
            return Content("Insert success!");
        }

        // PUT api/<AchievementController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, News news)
        {
            var temp = await _newsRepository.GetNewsById(id);
            if (temp == null)
            {
                return NoContent();
            }
            news.NewsId = id;
            await _newsRepository.Update(news);
            return Content("Update success!");
        }

        // DELETE api/<AchievementController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = await _newsRepository.GetNewsById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _newsRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
