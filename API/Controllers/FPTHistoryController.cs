using BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FPTHistoryController : ControllerBase
    {
        private readonly IFPTHistoryRepository _fPTHistoryRepository;
        public FPTHistoryController()
        {
            _fPTHistoryRepository = new FPTHistoryRepository();
        }
        // GET: api/<FPTHistoryController>
        [HttpGet]
        public async Task<IEnumerable<FPTHistory>> GetFPTHistorys()
        {
            return await _fPTHistoryRepository.GetAllFPTHistory();
        }

        // GET api/<FPTHistoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FPTHistory>> Get(int id)
        {
            var fptHistory = await _fPTHistoryRepository.GetFPTHistoryById(id);
            if (fptHistory == null)
            {
                return NotFound();
            }
            return fptHistory;
        }

        // GET api/<BlogController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Achievement>>> GetBlogByTitle(string name)
        {
            var fptHistory = await _fPTHistoryRepository.GetFPTHistoryByTitle(name);
            if (fptHistory == null)
            {
                return NotFound();
            }
            return Ok(fptHistory);
        }

        // POST api/<FPTHistoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FPTHistory fptHistory)
        {
            await _fPTHistoryRepository.Add(fptHistory);
            return Content("Insert success!");
        }

        // PUT api/<FPTHistoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, FPTHistory fptHistory)
        {
            var temp = await _fPTHistoryRepository.GetFPTHistoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            fptHistory.FPTHistoryId = id;
            await _fPTHistoryRepository.Update(fptHistory);
            return Content("Update success!");
        }

        // DELETE api/<FPTHistoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var temp = _fPTHistoryRepository.GetFPTHistoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _fPTHistoryRepository.Delete(id);
            return Content("Delete success!");
        }
    }
}
