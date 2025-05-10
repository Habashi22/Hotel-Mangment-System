using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class UsedPromoCodeController(IUsedPromoCodeService usedPromoCode,IPromoCodeService promoCode,UserManager<AppUser>userManager) : Controller
    {
		[Authorize(Roles = "ADMIN")]
		public ActionResult Index()
        {
            SelectList sL = new SelectList(promoCode.GetAll(), "Id", "Code");
            ViewBag.Codes = sL;
            ViewBag.Showreservations = true;

            SelectList ssL = new SelectList(userManager.Users.ToList(), "Id", "UserName");
            ViewBag.Users = ssL;
            return View(usedPromoCode.GetAllUsed());
        }
        [HttpPost]
		[Authorize]
		[ServiceFilter(typeof(AuthorAndAdminFilter))]
        public ActionResult Index(int id)
        {
            SelectList sL = new SelectList(promoCode.GetAll(), "Id", "Code", id);
            ViewBag.Codes = sL;
            ViewBag.Showreservations = false;

            SelectList ssL = new SelectList(userManager.Users.ToList(), "Id", "UserName", id);
            ViewBag.Users = ssL;            
            return View(usedPromoCode.GetAllUsedSamePromoCode(id));
        }
        [HttpPost]
		[Authorize(Roles="ADMIN")]
        public ActionResult GetAllUsedBySameUser(string userid)
        {
			SelectList sL = new SelectList(promoCode.GetAll(), "Id", "Code");
			ViewBag.Codes = sL;
			 sL = new SelectList(userManager.Users.ToList(), "Id", "UserName", userid);
            ViewBag.Users = sL;
			ViewBag.Showreservations = true;
			return View(nameof(Index),usedPromoCode.GetAllUsedBySameUser(userid));
        }
		[HttpPost]
		public ActionResult GetAllUsedByMe()
		{
			var userid=User.FindFirstValue(ClaimTypes.NameIdentifier);
			SelectList sL = new SelectList(promoCode.GetAll(), "Id", "Code");
			ViewBag.Codes = sL;
			sL = new SelectList(userManager.Users.ToList(), "Id", "UserName", User.FindFirstValue(ClaimTypes.NameIdentifier));
			ViewBag.Users = sL;
			ViewBag.Showreservations = true;
			return View(nameof(Index), usedPromoCode.GetAllUsedBySameUser(userid));
		}
		//public ActionResult GetAllUsedinSamereserv(int id)
		//{
		//    return View(usedPromoCode.GetAllUsedinSameReserv(id));
		//}               
		//public ActionResult GetAllreservUsedSamePromoCode(int id)
		//{

		//    return View(usedPromoCode.GetAllReservUsedSamePromoCode(id));
		//}       
	}
}
