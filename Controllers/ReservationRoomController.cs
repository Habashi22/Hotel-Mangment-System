using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class ReservationRoomController(IReservationRoom reservationRoom, IRoomService roomService) : Controller
    {
	
		public ActionResult Index()
        {
            return View(reservationRoom.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(reservationRoom.GetById(id));
        }

        // GET: ReservationRoomController/Create
        public ActionResult Create()
        {
            ViewBag.rooms = new SelectList(roomService.GetAll(), "Id", "Id");
            //ViewBag.users = new SelectList(userService.GetAll(), "Id", "Id");
            //ViewBag.reservations = new SelectList(reservationService.GetAll(), "Id", "Id");

            return View();
        }

        // POST: ReservationRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationRoomVM vm)
        {
            if (ModelState.IsValid)
            {
                reservationRoom.Create(vm);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.rooms = new SelectList(roomService.GetAll(), "Id", "Id");
            return View(vm);
        }





        //// GET: ReservationRoomController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ReservationRoomController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}





        // GET: ReservationRoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(reservationRoom.GetById(id));
        }

        // POST: ReservationRoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            var ResRoom = reservationRoom.GetById(id);

            try
            {
                reservationRoom.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ResRoom);
            }
        }
    }
}
