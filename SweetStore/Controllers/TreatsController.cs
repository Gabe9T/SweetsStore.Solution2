using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SweetStore.Models;

namespace SweetStore.Controllers
{
    public class TreatsController : Controller
    {
        private readonly SweetStoreContext _db;

        public TreatsController(SweetStoreContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Treats.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

            public ActionResult Details(int id)
        {
            var thisTreat = _db.Treats
                .Include(treat => treat.TreatFlavors)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        public ActionResult Edit(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTreat(int id)
        {
            var flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
            if (flavor == null)
            {
                return NotFound();
            }

            ViewBag.FlavorId = flavor.FlavorId;
            ViewBag.Treats = _db.Treats.ToList();
            return View(flavor);
        }

        [HttpPost]
public ActionResult AddFlavor(int id, int flavorId)
{
    var treat = _db.Treats.Include(t => t.TreatFlavors).FirstOrDefault(t => t.TreatId == id);
    var flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == flavorId);

    if (treat != null && flavor != null)
    {
        if (treat.TreatFlavors.Any(ft => ft.FlavorId == flavorId))
        {
            return RedirectToAction("Details", new { id = id });
        }

        var joinEntity = new TreatFlavor { TreatId = id, FlavorId = flavorId };
        _db.TreatFlavors.Add(joinEntity);
        _db.SaveChanges();
    }

    return RedirectToAction("Details", new { id = id });
}

    }
}