using Microsoft.AspNetCore.Mvc;
using Services;

namespace FPTEducationMVC.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public async Task<ActionResult> Index()
		{
			var p = await _blogService.GetBlogAll();
			return View(p);
		}
	}
}
