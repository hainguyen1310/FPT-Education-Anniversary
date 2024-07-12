using Microsoft.AspNetCore.Mvc;
using Services;

namespace FPTEducationMVC.Controllers
{
	public class FPTHistoryController : Controller
	{
		private readonly IFPTHistoryService _fPTHistoryService;

		public FPTHistoryController(IFPTHistoryService fPTHistoryService)
		{
			_fPTHistoryService = fPTHistoryService;
		}
		public async Task<ActionResult> Index()
		{
			var p = await _fPTHistoryService.GetFPTHistoryAll();
			return View(p);
		}
	}
}
