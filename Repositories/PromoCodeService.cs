
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MVCBookingFinal_YARAB_.Repositories
{
    public class PromoCodeService(ApplicationDbContext context) : IPromoCodeService
    {        
        public List<PromoCode> GetAll()
        {
            
            return context.PromoCodes.Include(p=>p.AddingUser).Include(pc => pc.UsedTimes).ToList();
        }
        public List<PromoCode> GetAllAddedBySingleUser(string id)
        {                        
                        
            return context.PromoCodes.Include(pc=>pc.AddingUser).Include(pc => pc.UsedTimes).Where(p => p.AddingUserID == id).ToList();
        }
        public PromoCode GetById(int id)
        {
            return context.PromoCodes.Include(pc => pc.AddingUser).Include(pc=>pc.UsedTimes).FirstOrDefault(pc=>pc.Id==id);
        }

        public void Create(PromoCodeViewModel pc,string userId)
        {
            PromoCode code = new PromoCode();
            code.ExpiryDate = pc.ExpiryDate;
            code.AddingUserID = userId;
            code.Code = pc.Code;
            code.Discount = (double)pc.discount;
            context.PromoCodes.Add(code);
            context.SaveChanges();
        }
        public void Update(PromoCodeViewModel pc)
        {
            var selectedpromocode = context.PromoCodes.FirstOrDefault(pc => pc.Id == pc.Id);
            selectedpromocode.ExpiryDate = pc.ExpiryDate;
            selectedpromocode.Code = pc.Code;
            selectedpromocode.AddingUserID = pc.AddingUserID;
			selectedpromocode.Discount = (double)pc.discount;
			selectedpromocode.IsActive=selectedpromocode.ExpiryDate > DateTime.Now ?  true :  false;
			context.PromoCodes.Update(selectedpromocode);
            context.SaveChanges();
        }

        public void Delete(PromoCode pc)
        {
            var selectedpromocode= context.PromoCodes.FirstOrDefault(p => p.Id == pc.Id);
            selectedpromocode.IsActive = false;
            context.PromoCodes.Update(pc);
            context.SaveChanges();
        }        
    }
}
