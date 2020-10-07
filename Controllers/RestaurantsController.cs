using System;
using System.Collections.Generic;
using BestRestaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Controllers
{
    
    public class RestaurantsController : Controller
    {
        private readonly BestRestaurantsContext _db;
        public RestaurantsController(BestRestaurantsContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            View.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Restaurant restaurant )
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}