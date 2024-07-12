using BusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FPTEducationMVC.Controllers
{
    public class AchievementController : Controller
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var p = await _achievementService.GetAchievementAll();
            return View(p);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var p = await _achievementService.GetAchievementById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Achievement a)
        {
            if (ModelState.IsValid)
            {
                await _achievementService.Create(a);
                return RedirectToAction(nameof(Index));
            }
            return View(a);

        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var p = await _achievementService.GetAchievementById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Achievement p)
        {
            if (id != p.AchievementId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _achievementService.Update(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _achievementService.GetAchievementById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Achievement p)
        {
            try
            {
                await _achievementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

