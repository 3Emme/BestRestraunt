using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using BestRestaurants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BestRestaurants.Controllers
{
    public class ReviewsController: Controller
    {
        private readonly BestRestaurantsContext _db;
        public ReviewsController(BestRestaurantsContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Review> model = _db.Reviews.ToList();
            return View(model);
        }
        public ActionResult Create(int id)
        {
            ViewBag.RestaurantId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Review review )
        {
            
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Review model =  _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(model);
        }
        
        public ActionResult Delete(int id)
        {
            Review review = _db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            _db.Reviews.Remove(review);
            _db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public ActionResult Edit(int id)
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "RestaurantName");
            var thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }
        [HttpPost]
        public ActionResult Edit(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string reviewUser)
        {
        List<Review> model = _db.Reviews.Where(x => x.ReviewUser.Contains(reviewUser)).ToList();
        return View("Index", model);
        }
    }
}