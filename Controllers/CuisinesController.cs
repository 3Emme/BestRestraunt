using System;
using System.Collections.Generic;
using BestRestaurants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BestRestaurants.Controllers
{
    public class CuisinesController : Controller
    {
        private readonly BestRestaurantsContext _db;
        public CuisinesController(BestRestaurantsContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cuisine cuisine )
        {
            _db.Cuisines.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Cuisine cuisine =  _db.Cuisines.FirstOrDefault(x => x.CuisineId == id);
            List<Restaurant> restaurants = _db.Restaurants.Where(x => x.CuisineId == id).ToList();
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("cuisine", cuisine);
            model.Add("restaurants", restaurants);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
            return View(thisCuisine);
        }

        [HttpPost]
        public ActionResult Edit(Cuisine cuisine)
        {
            _db.Entry(cuisine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Cuisine cuisine = _db.Cuisines.FirstOrDefault(x => x.CuisineId == id);
            List<Restaurant> restaurants = _db.Restaurants.Where(x => x.CuisineId == id).ToList();
            if(restaurants.Count != 0)
            {
                return RedirectToAction("Error");//error msg
            }
            else
            {
                _db.Cuisines.Remove(cuisine);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
             
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}