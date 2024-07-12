using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementRepository _achievementRepository;
        public AchievementController()
        {
            _achievementRepository = new AchievementRepository();
        }
        // GET: api/<AchievementController>
        [HttpGet]
        public async Task<IEnumerable<Achievement>> GetAchievements()
        {
            var list = await _achievementRepository.GetAllAchievement();
            return list;
        }

        // GET api/<AchievementController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achievement>> Get(int id)
        {
            var achievement = await _achievementRepository.GetAchievementById(id);
            if (achievement == null)
            {
                return NotFound();
            }
            return achievement;
        }
        // GET api/<AchievementController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Achievement>>> GetAchievementByTitle(string name)
        {
            var achievement = await _achievementRepository.GetAchievementByTitle(name);
            if (achievement == null)
            {
                return NotFound();
            }
            return Ok(achievement);
        }

        // POST api/<AchievementController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Achievement achievement)
        {
            await _achievementRepository.Add(achievement);
            return Content("Insert success!");
        }

        // PUT api/<AchievementController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Achievement achievement)
        {
            var temp = await _achievementRepository.GetAchievementById(id);
            if (temp == null)
            {
                return NoContent();
            }
            achievement.AchievementId = id;
            await _achievementRepository.Update(achievement);
            return Content("Update success!");
        }

        // DELETE api/<AchievementController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _achievementRepository.GetAchievementById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _achievementRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
