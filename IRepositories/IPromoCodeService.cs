namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IPromoCodeService
    {
        public List<PromoCode> GetAll();
        public PromoCode GetById(int id);
        public List<PromoCode> GetAllAddedBySingleUser(string id);
        public void Create(PromoCodeViewModel pc, string userId);

		public void Update(PromoCodeViewModel pc);
        public void Delete(PromoCode pc);
    }
}
