using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Models;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class InvoiceController(IInvoiceService InvoiceService,IReservationService reservationservice
        ,IPaymentMethodService paymentmethodservice,
        IPaymentService paymentservice) : Controller
    {
        // GET: InvoiceController
        [Authorize(Roles="ADMIN")]
        public ActionResult Index()
        {
          return View(InvoiceService.GetAll());
        }

        // GET: InvoiceController/Details/5
        //[ServiceFilter(typeof(AuthorAndAdminFilter))]
        [Authorize]
		public ActionResult Details(int id)
        {
            var invoice = InvoiceService.GetById(id);
			if (invoice is not null)
			{
				return View(invoice);
			}
			else
			{
				return Unauthorized();
			}
        }
        [Authorize]
		public ActionResult myInvoices()
		{
			return View("Index",InvoiceService.GetByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier)));
		}

        [HttpGet]
		public ActionResult Create(string id)
        {
            var stripepaymentmethod = new StripePaymentMethod()
            {
                AccountNumber = id,
                PaymentType = PaymentType.Stripe,
            };
            paymentmethodservice.CreateStripe(stripepaymentmethod);
            var payment=paymentservice.Create(stripepaymentmethod);
			int reservationid = (int)TempData.Peek("ReservationId");
            var reservation=reservationservice.getById(reservationid);
            reservation.reservationStatus = ReservationStatus.Confirmed;
            var invoice=InvoiceService.Create(reservation.Id, payment.Id);
            return RedirectToAction(nameof(Details), InvoiceService.GetById(invoice.Id));


		}
		[HttpGet]
		public ActionResult CreateWithCard(string amount)
		{
			ViewBag.Amount = amount;
			return View();
		}
		[HttpPost]
		public ActionResult CreateWithCard(CardPaymentViewModel vm)
        {
			int reservationid = (int)TempData.Peek("ReservationId");
			if (!ModelState.IsValid)
			{
				TempData["ReservationId"] = reservationid;
				return View(vm);
			}
			var cardPayment = new CardPaymentMethod()
			{

				CardNumber= vm.CardNumber,
				CVV=vm.CVV,
				ExpiryDate=vm.ExpiryDate,
				PaymentType = PaymentType.Card
			};
			paymentmethodservice.CreateCard(cardPayment);
			var payment = paymentservice.Create(cardPayment);
			var reservation = reservationservice.getById(reservationid);
			reservation.reservationStatus = ReservationStatus.Confirmed;
			var invoice = InvoiceService.Create(reservation.Id, payment.Id);
			return RedirectToAction(nameof(Details), InvoiceService.GetById(invoice.Id));

		}


	}
}
