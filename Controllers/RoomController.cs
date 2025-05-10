using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookingFinal_YARAB_.IRepositories;
using MVCBookingFinal_YARAB_.Models;
using MVCBookingFinal_YARAB_.Repositories;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class RoomController(IRoomService _roomService, ApplicationDbContext _context, IHotelService _hotelService) : Controller
    {
		// GET: RooomController
		[AllowAnonymous]
        public ActionResult Index()
        {
            return View(_roomService.GetAll());
        }
		[AllowAnonymous]
		// GET: RooomController/Details/5
		public ActionResult Details(int id)
		{
            return View(_roomService.GetById(id));
        }

		// GET: RooomController/Create
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create()
        {
			ViewBag.HotelSelectlist = new SelectList(_hotelService.GetAll(), "id", "Name");
			return View();
        }

        // POST: RooomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create(RoomViewModel vm)
        {
			ViewBag.HotelSelectlist = new SelectList(_hotelService.GetAll(), "id", "Name");

			if (vm.Images is null)
			{
				ModelState.AddModelError("", "Add images");
			}
			try
			{
				if (ModelState.IsValid)
				{
					//vm.Images = myImages;
					_roomService.Create(vm);
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

		// GET: RooomController/Edit/5
		[Authorize(Roles = "ADMIN")]

		public ActionResult Edit(int id)
        {
			var room = _roomService.GetById(id);
			ViewBag.HotelSelectlist = new SelectList(_hotelService.GetAll(), "id", "Name",room.HotelId);
            RoomViewModel vm = new()
            {
                //Capacity = room.Capacity,
                Floor = room.Floor,
                PricePerNight = room.PricePerNight,
                roomType = room.roomType,
                HotelId = room.HotelId,
            };
			ViewBag.Images = room.Images;
			return View(vm);
        }

        // POST: RooomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult Edit(RoomViewModel vm)
        {
			var room = _roomService.GetById((int)vm.Id);
			ViewBag.HotelSelectlist = new SelectList(_hotelService.GetAll(), "id", "Name", room.HotelId);
			try
            {
				if (ModelState.IsValid)
				{
					//var the = hotelservice.GetById((int)vm.id);
					_roomService.Update(vm);
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
		[Authorize(Roles = "ADMIN")]

		public ActionResult Delete(int id)
		{
			return View(_roomService.GetById(id));
		}

		// POST: HotelController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult Delete(int id, IFormCollection form)
		{
			try
			{
				_roomService.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(_roomService.GetById(id));
			}
		}

		
    }
}
