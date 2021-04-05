using Bakery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bakery.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, BakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      List<Treat> model = _db.Treats.ToList();
      return View(_db.Treats.OrderBy(m=>m.TreatName).ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      if (ModelState.IsValid)
      {  
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(treat);
    }

    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
          .Include(treat => treat.JoinEntities)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat, int flavorId)
    {
      bool matches = _db.FlavorTreat.Any(x => x.TreatId == treat.TreatId && x.FlavorId == flavorId);
      if (!matches && ModelState.IsValid)
      {
        if (flavorId != 0)
        {
          _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
        }
      }
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

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Search(string searchString)
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      var search = from m in _db.Treats
        select m;

      if (!String.IsNullOrEmpty(searchString))
      {
        search = search.Where(s => s.TreatName.Contains(searchString));
        return View(await Task.FromResult(search.ToList()));
      }
      else
      {
        List<Treat> model = _db.Treats.ToList();
        return View(_db.Treats.OrderBy(m=>m.TreatName).ToList());
      }
    }

  }
}