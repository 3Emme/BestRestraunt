using Microsoft.AspNetCore.Mvc;

namespace BestRestraunts.Controllers
{
    public class HomeController
    {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    }
}