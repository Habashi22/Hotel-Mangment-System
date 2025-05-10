
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCBookingFinal_YARAB_.Repositories
{
    public class UsedPromoCodeService(ApplicationDbContext context) : IUsedPromoCodeService
    {
        public List<UsedPromoCodes> GetAllReservUsedSamePromoCode(int PCid)
        {
            //return context.Reservations
            //    .Include(r => r.UsedPromoCodes)
            //    .Where(r => r.UsedPromoCodes.Any(upc => upc.PromoCodeId == PCid)).ToList();
            var promocodes = context.UsedPromoCodes.Include(p => p.Reservation).Where(r => r.PromoCodeId == PCid);
            return promocodes.ToList();
        }

        public List<UsedPromoCodes> GetAllUsed()
        {
            return context.UsedPromoCodes.Include(pc=>pc.PromoCode).Include(u=>u.Reservation).Include(u=>u.User).ToList();
        }

        public List<UsedPromoCodes> GetAllUsedBySameUser(string Userid)
        {
            return context.UsedPromoCodes.Where(u=>u.UserId==Userid).ToList();
        }

        public List<UsedPromoCodes> GetAllUsedinSameReserv(int reservid)
        {
            return context.UsedPromoCodes.Where(r=>r.ReservationId==reservid).ToList();
        }

        
        public List<UsedPromoCodes> GetAllUsedSamePromoCode(int PCid)
        {            
            var promocodes = context.UsedPromoCodes.Include(p=>p.User).Where(upc => upc.PromoCodeId == PCid);
            return promocodes.ToList();
        }

    }
}
