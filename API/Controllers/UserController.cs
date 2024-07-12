using BusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var list = await _userRepository.GetAllUser();
            return list;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // GET api/<UserController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name)
        {
            var users = await _userRepository.GetUserByName(name);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{name}/{pass}")]
        public async Task<ActionResult<User>> GetUserByUserNamePass(string name, string pass)
        {
            var user = await _userRepository.GetUserByUserNamePass(name,pass);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            await _userRepository.Add(user);
            return Content("Insert success!");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User user)
        {
            var temp = _userRepository.GetUserById(id);
            if (temp == null)
            {
                return NoContent();
            }
            user.UserId = id;
            await _userRepository.Update(user);
            return Content("Update success!");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _userRepository.GetUserById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _userRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
