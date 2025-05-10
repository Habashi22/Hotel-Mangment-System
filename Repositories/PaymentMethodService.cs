
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Models;

namespace WebAppMVCBookingFinal_YARAB_lication2.Repositories
{
    public class PaymentMethodService(ApplicationDbContext context) : IPaymentMethodService
    {
        public List<CardPaymentMethod> GetAllCards()
        {
          return context.CardPaymentMethods.ToList();
        }

        public List<StripePaymentMethod> GetAllStripes()
        {
            return context.StripePaymentMethod.ToList();
        }





        public StripePaymentMethod GetStripeById(int id)
        {
            return context.StripePaymentMethod.FirstOrDefault(str => str.Id == id);
        }

        public CardPaymentMethod GetCardsById(int id)
        {
            return context.CardPaymentMethods.FirstOrDefault(card => card.Id == id);

        }



       

        public void CreateStripe(StripePaymentMethod stripepaymentmethod)
        {
            var stripe= context.StripePaymentMethod.Add(stripepaymentmethod);
            context.SaveChanges();
          
        }

        public void CreateCard(CardPaymentMethod CardPaymentMethod)
        {

            var card = context.CardPaymentMethods.Add(CardPaymentMethod);
            context.SaveChanges();


        }







           public void UpdateStripe(StripePaymentMethodViewModel vm)
            {
            var stripe=context.StripePaymentMethod.FirstOrDefault(st=>st.Id == vm.Id);
            stripe.AccountNumber=vm.AccountNumber;
            context.StripePaymentMethod.Update(stripe);
            context.SaveChanges();
            
           
            }

        public void UpdateCard(CardPaymentViewModel vm)
        {


            var card = context.CardPaymentMethods.FirstOrDefault(c => c.Id == vm.Id);
            card.CardNumber = vm.CardNumber;
            card.CVV = vm.CVV;
            card.ExpiryDate = vm.ExpiryDate;


            context.CardPaymentMethods.Update(card);
            context.SaveChanges();

        }








        public void DeleteStripeMethod(int id)
        {
            var item = context.StripePaymentMethod.FirstOrDefault(item => item.Id == id);
            context.StripePaymentMethod.Remove(item);
            context.SaveChanges();


            
        }



        public void DeleteCardMethod(int id)
        {
            var item = context.CardPaymentMethods.FirstOrDefault(item => item.Id == id);
            context.CardPaymentMethods.Remove(item);
            context.SaveChanges();


        }


    }
}
