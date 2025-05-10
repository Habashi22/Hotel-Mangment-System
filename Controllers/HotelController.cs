using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookingFinal_YARAB_.Models;
using MVCBookingFinal_YARAB_.Repositories;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class HotelController(IHotelService hotelservice,ApplicationDbContext _context,ICityService _cityservice) : Controller
    {
        // GET: HotelController

        public ActionResult Index()
        {
			var flagValues = Enum.GetValues(typeof(AmenityEnum))
							 .Cast<AmenityEnum>()
							 .ToList();
            ViewBag.AmenityFlags = flagValues;
			return View(hotelservice.GetAll());
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            

            return View(hotelservice.GetById(id));
        }

        // GET: HotelController/Create
        [Authorize(Roles="ADMIN")]
        public ActionResult Create()
        {
            ViewBag.cityselectlist = new SelectList(_cityservice.GetAll(), "Id", "Name");
			return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult Create(HotelViewModel vm)
        {
			ViewBag.cityselectlist = new SelectList(_cityservice.GetAll(), "Id", "Name");

            if(vm.Images is null)
            {
                ModelState.AddModelError("", "Add images");
            }
			try
			{
                if(ModelState.IsValid)
                {
                    //vm.Images = myImages;
                    hotelservice.Create(vm);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(vm);
                }
            }
            catch
            {
                return View(vm);
            }
        }

		// GET: HotelController/Edit/5
		[Authorize(Roles = "ADMIN")]

		public ActionResult Edit(int id)
        {
			var hotel=hotelservice.GetById(id);
			ViewBag.cityselectlist = new SelectList(_cityservice.GetAll(), "Id", "Name",hotel.CityId);
            HotelViewModel vm = new()
            {
                Address = hotel.Address,
                city = hotel.city,
                Description = hotel.Description,
                id = hotel.id,
                CityId = hotel.CityId,
                Email = hotel.Email,
                Name = hotel.Name,
                PhoneNumber = hotel.PhoneNumber,
                starRating = hotel.starRating,
                Ameneties = hotel.Ameneties.Amenities,
                Longitude=hotel.Longitude,
                Latitude=hotel.Latitude
             
            };
			ViewBag.Images = hotel.Images;
            return View(vm);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult Edit(HotelViewModel vm)
        {
			var hotel = hotelservice.GetById((int)vm.id);
			ViewBag.cityselectlist = new SelectList(_cityservice.GetAll(), "Id", "Name", hotel.CityId);

			try
			{
                if (ModelState.IsValid)
                {
                    //var the = hotelservice.GetById((int)vm.id);
                    hotelservice.Update(vm);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
					return View(vm);
				}
            }
            catch
            {
                return View(vm);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult Favor(int hotelid,bool returntoreservation=false)
        {
            hotelservice.Favor(hotelid, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!returntoreservation)
            {
                return RedirectToAction("Details", new { id = hotelid });
            }
            else
            {

				//SearchViewModel myvm = JsonConvert.DeserializeObject<SearchViewModel>(TempData["myviewmodel"].ToString());
				//var result = roomService.GetCombinationsByHotelId(hotelid, myvm);

				//TempData["myviewmodel"] = JsonConvert.SerializeObject(myvm);
                return RedirectToAction("GoToHotel", "Reservation", new { id=hotelid });
            }

        }
		[HttpGet]
		[Authorize]
		public IActionResult UnFavor(int hotelid, bool returntoreservation = false)
		{
			hotelservice.RemoveFromFavorites(hotelid, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (returntoreservation == false)
            {
                return RedirectToAction("Details", new { id = hotelid });
            }else
            {
                int id = hotelid;
				return RedirectToAction("GoToHotel", "Reservation", new { id = hotelid });
			}
		}

		// GET: HotelController/Delete/5
		[Authorize(Roles = "ADMIN")]

		public ActionResult Delete(int id)
        {
            return View(hotelservice.GetById(id));
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult Delete(int id,IFormCollection form)
        {
            try
            {
                hotelservice.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(hotelservice.GetById(id));
            }
        }
    }
}
