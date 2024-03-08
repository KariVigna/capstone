using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Authorize]
    public class PrizesController : Controller
    {
        private readonly CapstoneContext _db;
        public PrizesController(CapstoneContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Prize> model = _db.Prizes.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prize prize)
        {
            _db.Prizes.Add(prize);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddKid(int id)
        {
            Prize thisPrize = _db.Prizes.FirstOrDefault(prizes => prizes.PrizeId == id);
            ViewBag.KidId = new SelectList(_db.Kids, "KidId", "Name");
            return View(thisPrize);
        }

        [HttpPost]
        public ActionResult AddKid(Prize prize, int kidId, int prizeId)
        {
            #nullable enable
            KidPrize? joinEntity = _db.KidPrizes.FirstOrDefault(join => (join.KidId == kidId && join.PrizeId == prize.PrizeId));
            #nullable disable
            if (joinEntity == null && kidId != 0)
            {
                            Prize thisPrize = _db.Prizes.FirstOrDefault(prize => prize.PrizeId == prizeId);
                            Kid thisKid = _db.Kids.FirstOrDefault(kid => kid.KidId == kidId);

                _db.KidPrizes.Add(new KidPrize() { KidId = kidId, PrizeId = prize.PrizeId });
                thisPrize.Cost -= thisKid.Total;
                _db.Prizes.Update(thisPrize);
                _db.Kids.Update(thisKid);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = prize.PrizeId });

        }

        // public ActionResult Edit(int id)
        // {
        //     Prize thisPrize = _db.Prizes.FirstOrDefault(prize => prize.PrizeId == id);
        //     ViewBag.KidId = new SelectList(_db.Kids, "KidId", "Name");
        //     return View(thisPrize);
        // }

        // [HttpPost]
        // public ActionResult Edit(Prize prize)
        // {
        //     _db.Prizes.Update(prize);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        // public ActionResult Delete(int id)
        // {
        //     Prize thisPrize = _db.Prizes.FirstOrDefault(prize => prize.PrizeId == id);
        //     return View(thisPrize);
        // }

        // [HttpPost, ActionName("Delete")]
        // public ActionResult DeleteConfirmed(int id)
        // {
        //     Prize thisPrize = _db.Prizes.FirstOrDefault(prize => prize.PrizeId == id);
        //     _db.Prizes.Remove(thisPrize);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
}
}
