using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Data;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class PaymentMethodsController(IPaymentMethodService paymentMethod ) : Controller
    {


        public IActionResult Index()
        {
            ViewBag.PaymentTypes = new List<SelectListItem>
        {
            //new SelectListItem { Value = "", Text = "Select Payment Type" },
            new SelectListItem { Value = "Card", Text = "Card" },
            new SelectListItem { Value = "Stripe", Text = "Stripe" }
        };

            return View();
        }

        public IActionResult GetAllCards()
        {
           var cards=  paymentMethod.GetAllCards();
           
            return View(cards);

        }
        public IActionResult GetAllStripe()
        {
            var stripe = paymentMethod.GetAllStripes();

            return View(stripe);

        }
        [HttpPost]
        public IActionResult RedirectToPaymentMethods(string paymentType)
        {
            if (paymentType == "Card")
            {
                return RedirectToAction("GetAllCards");
            }
            else if (paymentType == "Stripe")
            {
                return RedirectToAction("GetAllStripe");
            }

          
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------


       
        public  IActionResult GetStripeMethodById(int id)
        {
            if (id == null)
            {
                return NotFound("please enter id");
            }

            var stripemethod = paymentMethod.GetStripeById(id);
               
            if (stripemethod == null)
            {
                return NotFound("this id is not available");
            }

            return View(stripemethod);
        }

        public IActionResult GetCardMethodById(int id)
        {
            if (id == null)
            {
                return NotFound("please enter id");
            }

            var CardMethod = paymentMethod.GetCardsById(id);

            if (CardMethod == null)
            {
                return NotFound("this id is not available");
            }

            return View(CardMethod);
        }
        //------------------------------------------------------------------------------------------------------------------------

        // GET: StripePaymentMethods/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
       
        public IActionResult Create( StripePaymentMethod stripePayment)
        {
            if (ModelState.IsValid)
            {
               paymentMethod.CreateStripe(stripePayment);
                return RedirectToAction(nameof(GetAllStripe));
            }
            return View(stripePayment);
        }


        // GET: StripePaymentMethods/Create
        public IActionResult CreateCard()
        {
            return View();
        }


        [HttpPost]

        public IActionResult CreateCard(CardPaymentMethod CardPayment)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.CreateCard(CardPayment);
                return RedirectToAction(nameof(GetAllCards));
            }
            return View(CardPayment);
        }
        //--------------------------------------------------------------------------------------------------------------------

        // GET: PaymentMethods/Edit/5
        public IActionResult EditStripeMethod(int id)
        {
            

            var stripemethod =  paymentMethod.GetStripeById(id);
            var model = new StripePaymentMethodViewModel
            {
                Id = stripemethod.Id,
                AccountNumber = stripemethod.AccountNumber
            };

            return View(model);
        }

     
        [HttpPost]
      
        public IActionResult EditStripeMethod(StripePaymentMethodViewModel paymentMethodvm)
        {


            if (ModelState.IsValid) 
            {
                try
                {
                    paymentMethod.UpdateStripe(paymentMethodvm);
                    return RedirectToAction("GetAllStripe"); 
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while updating the Stripe Payment Method.");
                }
            }

           
            return View(paymentMethodvm);
        }





        public IActionResult EditCardMethod(int id)
        {


            var cardmethod = paymentMethod.GetCardsById(id);
            var model = new CardPaymentViewModel
            {
                Id = cardmethod.Id,
                ExpiryDate = cardmethod.ExpiryDate,

                CardNumber = cardmethod.CardNumber,
                CVV = cardmethod.CVV,

            };

            return View(model);
        }


        [HttpPost]

        public IActionResult EditCardMethod(CardPaymentViewModel paymentMethodvm)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    paymentMethod.UpdateCard(paymentMethodvm);
                    return RedirectToAction("GetAllCards");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while updating the Stripe Payment Method.");
                }
            }


            return View(paymentMethodvm);
        }






       
        public IActionResult DeleteStripeMethod(int id)
        {

            var stripeMethod = paymentMethod.GetStripeById(id); // Get the payment method
            if (stripeMethod == null)
            {
                return NotFound(); // Return NotFound if the payment method doesn't exist
            }

            return View(stripeMethod);
        }

        // POST: PaymentMethods/Delete/5


        [HttpPost, ActionName("DeleteStripeMethod")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedstripe(int id)
        {
            try
            {
                paymentMethod.DeleteStripeMethod(id); // Call service to delete the item
                return RedirectToAction(nameof(GetAllStripe)); // Redirect to the list view
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the Stripe payment method.");
                return View(); // Return to the view if there was an issue
            }
        }


        public IActionResult DeleteCardMethod(int id)
        {

            var cardMethod = paymentMethod.GetCardsById(id); // Get the payment method
            if (cardMethod == null)
            {
                return NotFound(); // Return NotFound if the payment method doesn't exist
            }

            return View(cardMethod);
        }

        [HttpPost, ActionName("DeleteCardMethod")]
       
        public IActionResult DeleteConfirmedcard(int id)
        {
            try
            {
                paymentMethod.DeleteCardMethod(id); // Call service to delete the item
                return RedirectToAction(nameof(GetAllCards)); // Redirect to the list view
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the Stripe payment method.");
                return View(); 
            }
        }

    }
}
