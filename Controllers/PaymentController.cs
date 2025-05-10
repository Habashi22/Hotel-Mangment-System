using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookingFinal_YARAB_.Models;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class PaymentController(IPaymentService payment) : Controller
    {
        // GET: PaymentController
        [Authorize(Roles="ADMIN")]
        public ActionResult Index()
        {
            return View(payment.GetAll());
        }
        [Authorize]
		public ActionResult getMyPayment()
		{
			return View(nameof(Index),payment.GetByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
		}
	}
}
