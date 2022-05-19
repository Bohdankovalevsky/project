using LiquidWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LiquidRepositories;
using LiquidCore;
using LiquidWebApp.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace LiquidWebApp.Controllers
{

    public class LiquidController : Controller
    {
        private readonly ICapacity capacityRep;
        private readonly ICompany companyRep;
        private readonly IVGPG vGPGRep;
        private readonly INicotine nicotineRep;
        private readonly Iliquidinfo iliquidinfoRep;

        public LiquidController(CapacityRepository CR, NicotineRepository NR, VGPGRepository vGPG, LiquidInfoRepository iliquidinfo, CompanyRepository CR1)
        {
            capacityRep = CR;
            companyRep = CR1;
            vGPGRep = vGPG;
            iliquidinfoRep = iliquidinfo;
            nicotineRep = NR;

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(LiquidINfo liquidinfo)
        {
            int capid = capacityRep.Set(liquidinfo.capacity.Ml).Id;
            int vgpgid = vGPGRep.Set(liquidinfo.vGPG.VgPg).Id;
            int comid = companyRep.Set(liquidinfo.company.CompanyName).Id;
            int nicid = nicotineRep.Set(liquidinfo.nicotine.Mg).Id;
            iliquidinfoRep.Create(liquidinfo, capid, comid, nicid, vgpgid);
            return View(); //RedirectToAction("LiquidsShowPage", "Liquid");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(iliquidinfoRep.Get(Id));
        }
        [HttpPost]
        public IActionResult Edit(LiquidINfo liquidinfo)
        {
            liquidinfo.vGPG = vGPGRep.Set(liquidinfo.vGPG.VgPg);
            liquidinfo.nicotine = nicotineRep.Set(liquidinfo.nicotine.Mg);
            liquidinfo.capacity = capacityRep.Set(liquidinfo.capacity.Ml);
            liquidinfo.company = companyRep.Set(liquidinfo.company.CompanyName);
            iliquidinfoRep.Edit(liquidinfo);
            return RedirectToAction("LiquidsShowPage", "Liquid");
        }
        [HttpGet]
        public IActionResult LiquidsShowPage(IEnumerable<LiquidINfo> liquidINfos)
        {
            if (liquidINfos == null)
                return View(iliquidinfoRep.GetAll());
            else
                return View(iliquidinfoRep.GetAll());
        }

        public IActionResult search(string text)
        {
            IEnumerable<LiquidINfo> list = iliquidinfoRep.searcher(text);
            return View("LiquidsShowPage", list);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            return View(iliquidinfoRep.Get(id));
        }
        [HttpPost]
        public IActionResult Remove(LiquidINfo liquidinfo)
        {

            iliquidinfoRep.Delete(liquidinfo.Id);
            return RedirectToAction("LiquidsShowPage", "Liquid");
        }
        public IActionResult ViewLiquid(int Id)
        {
            return View(iliquidinfoRep.Get(Id));
        }

    }
}
