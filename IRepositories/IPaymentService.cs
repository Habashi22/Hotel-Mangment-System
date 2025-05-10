namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IPaymentService
    {
        public List<Payment> GetAll();
        public Payment GetById(int Id);
        public Payment Create(PaymentMethod pm);
		public void Delete(int id);
        public List<Payment> GetByUserId(string userId);

	}
}
