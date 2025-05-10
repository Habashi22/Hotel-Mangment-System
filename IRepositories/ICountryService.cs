using MVCBookingFinal_YARAB_.Models;
using MVCBookingFinal_YARAB_.ViewModels;

namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface ICountryService
	{
		public List<Country> GetAll();
		public Country GetById(int id);
		public void Create(CountryViewModel vm);
		public void Update(CountryViewModel vm);
		public void Delete(int id);
	}
}
