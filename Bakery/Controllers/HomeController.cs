using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly BakeryContext _db;
    public HomeController(BakeryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      var flavors = _db.Flavors.ToList();
      var treats = _db.Treats.ToList();
      Dictionary<string, object> model = new Dictionary<string, object> {};
      model.Add("flavors", flavors);
      model.Add("treats", treats);
      return View(model);
    }

    public ActionResult About()
    {
      return View();
    }

    public ActionResult Contact()
    {
      return View();
    }

  }
}