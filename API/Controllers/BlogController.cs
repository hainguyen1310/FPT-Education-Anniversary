using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController()
        {
            _blogRepository = new BlogRepository();
        }
        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            var list = await _blogRepository.GetAllBlog();
            return list;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var blog = await _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return blog;
        }

        // GET api/<BlogController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogByTitle(string name)
        {
            var blogs = await _blogRepository.GetBlogByTitle(name);
            if (blogs == null)
            {
                return NotFound();
            }
            return Ok(blogs);
        }
        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Blog blog)
        {
            await _blogRepository.Add(blog);
            return Content("Insert success!");
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Blog blog)
        {
            var temp = _blogRepository.GetBlogById(id);
            if (temp == null)
            {
                return NoContent();
            }
            blog.BlogId = id;
            await _blogRepository.Update(blog);
            return Content("Update success!");
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _blogRepository.GetBlogById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _blogRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
