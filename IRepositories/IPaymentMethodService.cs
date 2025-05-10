namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IPaymentMethodService
    {
       

        public List<CardPaymentMethod> GetAllCards();
        public List<StripePaymentMethod> GetAllStripes();




       
        public StripePaymentMethod GetStripeById(int id);
        public CardPaymentMethod GetCardsById(int id);




        void CreateStripe(StripePaymentMethod stripepaymentmethod);
        void CreateCard(CardPaymentMethod CardPaymentMethod);






        void UpdateStripe(StripePaymentMethodViewModel StripePaymentMethodViewModel);
        void UpdateCard(CardPaymentViewModel CardpaymentMethod);

        void DeleteStripeMethod(int id);
        void DeleteCardMethod(int id);




    }
}
