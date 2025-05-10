using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class PromoCodeController(IPromoCodeService promoCode,UserManager<AppUser> userManager) : Controller
    {
        // GET: PromoCodeController
        [Authorize(Roles="ADMIN")]
        public ActionResult Index()
        {
            SelectList sL = new SelectList(userManager.Users.ToList(), "Id", "FirstName");
            ViewBag.Users = sL;
            return View(promoCode.GetAll());
        }
        [HttpPost]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Index(string id)
        {
            SelectList sL = new SelectList(userManager.Users.ToList(), "Id", "FirstName", id);
            ViewBag.Users = sL;
            return View(promoCode.GetAllAddedBySingleUser(id));
        }

		// GET: PromoCodeController/Details/5
		[Authorize(Roles = "ADMIN")]
		public ActionResult Details(int id)
        {
            return View(promoCode.GetById(id));
        }

		// GET: PromoCodeController/Create
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create(string id)
        {
            var addinguser = userManager.Users.FirstOrDefault(au => au.Id == id);
            ViewBag.User = userManager.Users.ToList();
            return View();
        }

        // POST: PromoCodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create(PromoCodeViewModel PC)
        {
           // var addinguser = userManager.Users.FirstOrDefault(au => au.Id == PC.AddingUser.Id);
                ViewBag.User = userManager.Users.ToList();
            if (ModelState.IsValid)
            {
                promoCode.Create(PC, User.FindFirstValue(ClaimTypes.NameIdentifier));

                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(PC);
                }
            }
            return View(PC);
        }

		// GET: PromoCodeController/Edit/5
		[Authorize(Roles = "ADMIN")]
		public ActionResult Edit(int id)
        {
            ViewBag.User = userManager.Users.ToList();
            PromoCodeViewModel pc = new();
            var promocode = promoCode.GetById(id);
            pc.ExpiryDate = promocode.ExpiryDate;
            pc.Code = promocode.Code;
            pc.AddingUserID = promocode.AddingUserID;
            pc.discount = (int)(promocode.Discount);
            return View(pc);
        }

        // POST: PromoCodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Edit(PromoCodeViewModel Pc)
        {
           //ViewBag.User = userManager.Users.ToList();
            if (Pc !=null)
            {
                if (ModelState.IsValid)
                {
                    promoCode.Update(Pc);

                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View(Pc);
                    }
                }
                return View(Pc);
            }
            return View(Pc);
        }
		[Authorize(Roles = "ADMIN")]

		// GET: PromoCodeController/Delete/5
		public ActionResult Delete(int id)
        {
            return View(promoCode.GetById(id));
        }

        // POST: PromoCodeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Delete(int id,IFormCollection ZFT)
        {
            var pc =promoCode.GetById(id);
            if (pc != null)
            {
                if (ModelState.IsValid)
                {
                    promoCode.Delete(pc);

                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View(pc);
                    }
                }
                return View(pc);
            }
            return View(pc);
        }
    }
}
