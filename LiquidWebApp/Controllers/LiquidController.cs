using LiquidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LiquidRepositories;
using LiquidCore;
using LiquidWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LiquidWebApp.Controllers
{/*
    public class LiquidController : Controller
    {
        private readonly LiquidInfoRepository _liquidInfoRepository;
        public LiquidController(LiquidInfoRepository liquidInfoRepository)
        {
            _liquidInfoRepository = liquidInfoRepository;
        }


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
    }*/

    public class LiquidController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public LiquidController(ApplicationDbContext applicationDbContext)
        {
            _ctx = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(LiquidINfo liquidinfo)
        {
           _ctx.LInfo.Add(liquidinfo);
            _ctx.SaveChanges();
            return RedirectToAction("LiquidsShowPage","Liquid");
        }
       [HttpGet]
                  public IActionResult LiquidsShowPage()
        {
            return View(_ctx.LInfo
                .Include(d => d.capacity)
                .Include(d => d.company)
                .Include(d => d.nicotine)
                .Include(d => d.vGPG).
                ToList());
        }
    }
}
