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
        private readonly LiquidInfoRepository _liquidInfoRepository;
        private readonly CapacityRepository _capacityRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly NicotineRepository _nicotineRepository;
        private readonly VGPGRepository _vGPGRepository;
        public LiquidController(LiquidInfoRepository liquidInfoRepository, CapacityRepository capacityRepository, CompanyRepository companyRepository, NicotineRepository nicotineRepository, VGPGRepository vGPGRepository)
        {
            _liquidInfoRepository = liquidInfoRepository;
            _capacityRepository = capacityRepository;
            _companyRepository = companyRepository;
            _nicotineRepository = nicotineRepository;
            _vGPGRepository = vGPGRepository;          
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(LiquidINfo liquidinfo)
        {
            int capid = _capacityRepository.Set(liquidinfo.capacity.Ml).Id;
            int comid = _companyRepository.Set(liquidinfo.company.CompanyName).Id;
            int nicid = _nicotineRepository.Set(liquidinfo.nicotine.Mg).Id;
            int vgpgid = _vGPGRepository.Set(liquidinfo.vGPG.VgPg).Id;
           _liquidInfoRepository.CreateAsync(liquidinfo, capid, comid,nicid,vgpgid);
            return RedirectToAction("LiquidsShowPage","Liquid");
        }
       [HttpGet]
        public IActionResult LiquidsShowPage()
        {
            return View(_liquidInfoRepository.GetAll());
        }
    }
}
