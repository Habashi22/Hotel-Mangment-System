namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IUsedPromoCodeService
    {
        public List<UsedPromoCodes> GetAllUsed();
        //public List<UsersUsedSamePromoCodeViewModel> GetAllUsedSamePromoCode(int PCid);
        public List<UsedPromoCodes> GetAllUsedSamePromoCode(int PCid);
        public List<UsedPromoCodes> GetAllReservUsedSamePromoCode(int PCid);
        public List<UsedPromoCodes> GetAllUsedBySameUser(string Userid);
        public List<UsedPromoCodes> GetAllUsedinSameReserv(int reservid);
        

    }
}
