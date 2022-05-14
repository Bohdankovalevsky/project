using Microsoft.AspNetCore.Mvc;
using LiquidRepositories;
using LiquidCore;

namespace LiquidWebApp.Controllers
{
    public class LiquidController : Controller
    {
        private readonly LiquidInfoRepository _liquidInfoRepository;
        public LiquidController(LiquidInfoRepository liquidInfoRepository)
        {
            _liquidInfoRepository = liquidInfoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new LiquidINfo());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LiquidINfo model)
        {
            if (ModelState.IsValid)
            {
                await _liquidInfoRepository.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
