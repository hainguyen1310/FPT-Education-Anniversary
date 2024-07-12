using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {
        private readonly IFeedBacksRepository _feedBacksRepository;
        public FeedBacksController()
        {
            _feedBacksRepository = new FeedBacksRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<FeedBacks>> GetFeedBacks()
        {
            return await _feedBacksRepository.GetAllFeedBacks();
        }

        // GET api/<FeedBacksController>/User/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<FeedBacks>>> GetFeedBacksById(int id)
        {
            var feedBacks = await _feedBacksRepository.GetFeedBacksById(id);
            if (feedBacks == null)
            {
                return NotFound();
            }
            return Ok(feedBacks);
        }

        // GET api/<FeedBacksController>/3/6
        [HttpGet("{userId}/{blogId}")]
        public async Task<ActionResult<IEnumerable<FeedBacks>>> GetFeedBacksByUserIdBlogId(int userId, int blogId)
        {
            var feedBacks = await _feedBacksRepository.GetFeedBacksByUserIdBlogId(userId, blogId);
            if (feedBacks == null)
            {
                return NotFound();
            }
            return Ok(feedBacks);
        }

        // POST api/<FeedBacksController>
        [HttpPost]
        public async Task<ActionResult> Post(FeedBacks feedBacks)
        {
            await _feedBacksRepository.Add(feedBacks);
            return Content("Insert success!");
        }

        // PUT api/<FeedBacksController>/5
        [HttpPut("{userId}/{blogId}")]
        public async Task<ActionResult> Put(int userId, int blogId, FeedBacks feedBacks)
        {
            var temp = _feedBacksRepository.GetFeedBacksByUserIdBlogId(userId, blogId);
            if (temp == null)
            {
                return NoContent();
            }
            feedBacks.UserId = userId;
            feedBacks.BlogId = blogId;
            await _feedBacksRepository.Update(feedBacks);
            return Content("Update success!");
        }

        // DELETE api/<FeedBacksController>/5
        [HttpDelete("{userId}/{blogId}")]
        public async Task<ActionResult> Delete(int userId, int blogId)
        {
            var temp = _feedBacksRepository.GetFeedBacksByUserIdBlogId(userId, blogId);
            if (temp == null)
            {
                return NoContent();
            }
            await _feedBacksRepository.Delete(userId, blogId);
            return Content("Delete success!");
        }
    }
}
