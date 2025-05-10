using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Data;
using MVCBookingFinal_YARAB_.Models;
using Stripe;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class ReviewsController(IReviewsService ReviewContext,IHotelService HotelContext, IUserService _userService, UserManager<AppUser> _userManager) : Controller
    {

        // GET: Reviews
        public IActionResult Index()
        {
            
                var allReviews = ReviewContext.GetAllReview();
            return View(allReviews);

            //}
            //    var user = _userManager.GetUserId(User);
            //    if (string.IsNullOrEmpty(user))
            //    {
            //        return Unauthorized();
            //    }

            //    var userReviews = ReviewContext.GetReviewByUser(user);

            //    return View(userReviews);

                 return View(allReviews);
            
        }
        [Authorize]
        public IActionResult MyReviews()
        {
            
                var allReviews = ReviewContext.GetReviewByUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
                 return View("Index",allReviews);
            
        }
      
     

        // GET: Reviews/Details/5
        public IActionResult GetTopReviews()
        {
            var reviews = ReviewContext.GetAllReview();
            return View("Index",reviews);
          
        }
        
        public IActionResult Details(int id)
        {
            var review = ReviewContext.GetReviewById(id);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == review.UserId);
            var hotel = HotelContext.GetById(review.HotelId);
            ViewBag.Hotel = hotel.Name;


            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            //var review = ReviewContext.GetReviewById(id);
            //var hotel = HotelContext.GetById(review.HotelId);
            //ViewBag.Hotel = hotel.Name;
            ViewBag.Hotel = new SelectList(HotelContext.GetAll(), "id", "Name");
          

            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        //[Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public IActionResult Create( ReviewViewModel review)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Unauthorized();
            }
           

            if (ModelState.IsValid)
            {

                ReviewContext.CreateReview(review, userId);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Hotel = new SelectList(HotelContext.GetAll(), "id", "Name");
           
            return View(review);
        }

        // GET: Reviews/Edit/5
        //[Authorize(Roles = "User")]
        [ServiceFilter(typeof(AuthorFilter))]
        public IActionResult Edit(int id)
        {
            var review = ReviewContext.GetReviewById(id);
            ReviewViewModel reviewViewModel = new()
            {
                //Id = id,
                Rating = review.Rating,
                Description = review.Description,
                //ReviewDate = review.ReviewDate
            };
          
            if (review == null)
            {
                return NotFound();
            }
            return View(reviewViewModel);

        }

        // POST: Reviews/Edit/5
        [HttpPost]
		//[Authorize(Roles = "User")]
		[ServiceFilter(typeof(AuthorFilter))]
		[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,HotelId,UserId,Rating,Description,ReviewDate")] ReviewViewModel reviewVM)
        {
            try
            {
                ReviewContext.UpdateReview(reviewVM);
            }

            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(reviewVM);
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Reviews/Delete/5
        [Authorize]
        [ServiceFilter(typeof(AuthorAndAdminFilter))]
        public IActionResult Delete(int id)
        {
            var review = ReviewContext.GetReviewById(id);
            var hotel = HotelContext.GetById(review.HotelId);
            var user = _userManager.Users.FirstOrDefault(u => u.Id == review.UserId);
            ViewBag.UserName = user.UserName;
            ViewBag.Hotel = hotel.Name;


            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
		[ServiceFilter(typeof(AuthorAndAdminFilter))]
		[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var review = ReviewContext.GetReviewById(id);
            if (review != null)
            {
                ReviewContext.DeleteReview(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }

}
