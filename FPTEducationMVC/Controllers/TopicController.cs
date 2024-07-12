using Microsoft.AspNetCore.Mvc;
using Services;

namespace FPTEducationMVC.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        public async Task<ActionResult> Index()
        {
            var p = await _topicService.GetTopicAll();

            return View(p);
        }
    }
}
