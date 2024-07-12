using BusinessLogic.Model;
using FPTEducationMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using System.Security.Claims;
using FPTEducationMVC.Common;

namespace FPTEducationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
		private readonly IAchievementService _achievementService;
        private readonly IBlogService _blogService;
        private readonly IFeedBacksService _feedBacksService;
        private readonly IFPTHistoryService _fPTHistoryService;
        private readonly IMessageService _messageService;
        private readonly ITopicService _topicService;
        private readonly ITopicCategoryService _topicCategoryService;
        private readonly IUserService _userService;
        private readonly INewsService _newsService;
		public HomeController(IAchievementService achievementService, IBlogService blogService, IFeedBacksService feedBacksService
            , IFPTHistoryService fPTHistoryService, IMessageService messageService, ITopicService topicService, ITopicCategoryService topicCategoryService,
            IUserService userService, INewsService newsService, HttpClient httpClient)
        {
            _achievementService = achievementService;
            _blogService = blogService;
            _feedBacksService = feedBacksService;
            _topicService = topicService;
            _topicCategoryService = topicCategoryService;
            _userService = userService;
            _fPTHistoryService = fPTHistoryService;
            _messageService = messageService;
            _newsService = newsService;
			_httpClient = httpClient;
		}

        public async Task<ActionResult> Index()
        {
            var achievements = await _achievementService.GetAchievementAll();
            var blogs = await _blogService.GetBlogAll();
            var feedbacks = await _feedBacksService.GetFeedBacksAll();
            var topics = await _topicService.GetTopicAll();
            var topicCategories = await _topicCategoryService.GetTopicCategoryAll();
            var users = await _userService.GetUsersAll();
            var fptHistorys = await _fPTHistoryService.GetFPTHistoryAll();
            var messages = await _messageService.GetMessageAll();
            var news = await _newsService.GetNewsAll();
            var viewModel = new IndexViewModel
            {
                Achievements = achievements,
                Blogs = blogs,
                FeedBacks = feedbacks,
                TopicDTOs = topics,
                TopicCategoriess = topicCategories,
                User = users,
                FPTHistorys = fptHistorys,
                Messages = messages,
                News = news
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
			TempData["ReturnUrl"] = ReturnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(UserLogin model)
		{
			if (ModelState.IsValid)
			{
				var username = model.UserName;
				var password = CommonContext.EncryptMD5(model.Password);
				User user = await _userService.GetUserByUserNamePass(username, password);
				if (user != null)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				ModelState.AddModelError("Error",
								 "Please input field full!");
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult UseChatGPT()
		{
			return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public async Task<IActionResult> UseChatGPT(string query)
		{
			var response = await _httpClient.GetAsync($"https://localhost:7172/api/GPT/UseChatGPT?query={Uri.EscapeDataString(query)}");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				ViewBag.Response = result;
			}
			else
			{
				ViewBag.Response = $"Error: {response.StatusCode}";
			}
			return RedirectToAction("Index", "Home");
		}

	}
}
