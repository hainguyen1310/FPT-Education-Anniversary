using Microsoft.AspNetCore.Mvc;
using Services;

namespace FPTEducationMVC.Controllers
{
    public class TopicCategoryController : Controller
    {
        private readonly ITopicCategoryService _topicCategoryService;

        public TopicCategoryController(ITopicCategoryService topicCategoryService)
        {
            _topicCategoryService = topicCategoryService;
        }
        public async Task<ActionResult> Index()
        {
            var p = await _topicCategoryService.GetTopicCategoryAll();
            return View(p);
        }
    }
}
