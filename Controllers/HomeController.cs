using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCBookingFinal_YARAB_.Models;
using Stripe.Checkout;
using Stripe;
using Stripe8.Models;

namespace MVCBookingFinal_YARAB_.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
	private readonly StripeSettings _stripeSettings;
	private readonly IHttpContextAccessor _httpContextAccessor;
	public HomeController(ILogger<HomeController> logger, IOptions<StripeSettings> stripeSettings, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
		_stripeSettings = stripeSettings.Value;
		_httpContextAccessor = httpContextAccessor;
	}
	//[ServiceFilter(typeof(AuthorFilter))]
	[AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
	public IActionResult Maps()
	{
		return View();
	}
	//[Authorize(Roles ="ADMIN")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

	public IActionResult CreateCheckoutSession(string amount)
	{
		var baseUrl = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host;
		var currency = "usd"; // Currency code
		var successUrl = $"{baseUrl}/Invoice/Create/session_id={{CHECKOUT_SESSION_ID}}";
		var cancelUrl = $"{baseUrl}/Home/cancel";
		StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

		var options = new SessionCreateOptions
		{
			PaymentMethodTypes = new List<string>
				{
					"card"
				},
			LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							Currency = currency,
							UnitAmount = Convert.ToInt32(Math.Ceiling(decimal.Parse(amount))) * 100,  // Amount in smallest currency unit (e.g., cents)
                            ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = "Product Name",
								Description = "Product Description"
							}
						},
						Quantity = 1
					}
				},
			Mode = "payment",
			SuccessUrl = successUrl,
			CancelUrl = cancelUrl
		};

		var service = new SessionService();
		var session = service.Create(options);
		//var successUrl = $"{baseUrl}/Invoice/Create/{session.Id}";
		options.SuccessUrl = $"{baseUrl}/Invoice/Create/{session.Id}";
		session.SuccessUrl= $"{baseUrl}/Invoice/Create/{session.Id}"; 


		return Redirect(session.Url);
	}
	[HttpGet]
	public async Task<IActionResult> success()
	{

		return RedirectToAction("Index","Home");
	}

	public IActionResult cancel()
	{
		return View("Index");
	}

}
