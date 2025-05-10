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

namespace MVCBookingFinal_YARAB_.Controllers
{
        public class FavoritesController(IFavoritesService _favoritesService,IHotelService _hotelService, IUserService _userService ,UserManager<AppUser> _userManager) : Controller
        {

		// GET: Favorites
		[Authorize]
		public IActionResult Index(bool foruser=false)
            {
            if (User.IsInRole("ADMIN".ToUpper())&&!foruser)
            {
            
                var allFavorites = _favoritesService.GetAllFavorites();
           
                return View(allFavorites);
            }
            var user = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(user))
            {
                return Unauthorized(); 
            }


            var userFavs = _favoritesService.GetFavoritesByUser(user);
                return View(userFavs);
           
            }

        // GET: Favorites/Details/5
        // [Authorize(Roles = "ADMIN")]
        [Authorize]
        public IActionResult Details(int id)
            {

                var favorite = _favoritesService.GetFavoriteById(id);


            var user = _userManager.Users.FirstOrDefault(u => u.Id == favorite.UserId);
            if (favorite == null)
                {
                    return NotFound();
                }
         
           
            return View(favorite);
            }

            // GET: Favorites/Create
            public IActionResult Create()
            {
            var hotels = _hotelService.GetAll()
              .Where(h => !(h.Favorites.Select(f => f.UserId).Contains(User.FindFirstValue(ClaimTypes.NameIdentifier))))
             .Select(h => new FavoritesViewModel { HotelId = h.id, HotelName = h.Name })
             .ToList();

            ViewBag.Hotels = new SelectList(hotels, "HotelId", "HotelName");
            return View();
            }

            // POST: Favorites/Create
        [HttpPost]
       // [Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult Create(FavoritesViewModel favoriteVM)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Unauthorized(); 
            }

            _favoritesService.CreateFavorite(favoriteVM, userId);
            return RedirectToAction(nameof(Index));
        }



		// GET: Favorites/Delete/5
		// [Authorize(Roles = "ADMIN")]
		[Authorize]
		public IActionResult Delete(int id)
            {

                var favorite = _favoritesService.GetFavoriteById(id);
            //var user = _userManager.Users.FirstOrDefault(u => u.Id == favorite.UserId);
            if (favorite == null)
                {
                    return NotFound();
                }

                return View(favorite);
            }

            // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult DeleteConfirmed(int id)
            {
                var favorite = _favoritesService.GetFavoriteById(id);
                if (favorite != null)
                {
                    _favoritesService.DeleteFavorite(id);
                }

                return RedirectToAction(nameof(Index));
            }

        }

    }
