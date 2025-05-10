

using Microsoft.EntityFrameworkCore;

namespace MVCBookingFinal_YARAB_.Repositories
{
    public class PaymentService(ApplicationDbContext context):IPaymentService
    {
        public List<Payment> GetAll()
        {
            return context.Payments.Include(p=>p.payment).ToList();
        }
        public Payment Create(PaymentMethod pm)
        {
            
            Payment payment = new Payment();
            payment.PaymentDate = DateTime.Now;
            payment.PaymentMethodId = pm.Id;
            payment.TransactionId = Guid.NewGuid().ToString();
            payment.status = "confirmed";
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment;
		}

        public void Delete(int id)
        {
            var selectedp=context.Payments.FirstOrDefault(p=>p.Id== id);
			selectedp.status = "canceled";
            context.Payments.Update(selectedp);
            context.SaveChanges();
        }

        

        public Payment GetById(int Id)
        {
            return context.Payments.Include(p => p.payment).FirstOrDefault(p=>p.Id == Id);
        }

		public List<Payment> GetByUserId(string userId)
		{
			return context.Payments.Include(p => p.payment).Include(p=>p.invoice).ThenInclude(i=>i.Reservation).ThenInclude(r=>r.Reserved).Where(p => p.invoice.Reservation.Reserved.FirstOrDefault().UserId==userId).ToList();
		}
	}
}
