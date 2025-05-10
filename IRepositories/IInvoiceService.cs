using Microsoft.EntityFrameworkCore;

namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface IInvoiceService
	{

		public List<Invoice> GetAll();

		public List<Invoice> GetByUserId(string id);

		public Invoice GetById(int id);
		public Invoice Create(int reservationid, int paymenttid);
	}
}
