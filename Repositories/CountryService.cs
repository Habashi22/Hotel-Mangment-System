using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Data;
using MVCBookingFinal_YARAB_.Helpers;
using MVCBookingFinal_YARAB_.IRepositories;
using MVCBookingFinal_YARAB_.Models;
using MVCBookingFinal_YARAB_.ViewModels;

namespace MVCBookingFinal_YARAB_.Repositories
{
	public class CountryService(ApplicationDbContext context,IWebHostEnvironment _env ) : ICountryService
	{

		public List<Country> GetAll()
		{
			return context.Countries.Include(c => c.Cities).ThenInclude(C => C.Hotels).ThenInclude(h => h.Rooms).Where(c=> !c.isDeleted ).ToList();
		}

		public Country GetById(int id)
		{
			return context.Countries.Include(c => c.Cities).ThenInclude(C => C.Hotels).ThenInclude(h => h.Rooms).SingleOrDefault(c=>c.Id==id);
		}
		public void Create(CountryViewModel vm)
		{
			Country cntry = new()
			{
				Name = vm.Name,
				Image = vm.Image.Save(_env)
			};

			context.Countries.Add(cntry);
			context.SaveChanges();
		}

		public void Update(CountryViewModel vm)
		{
			var cntry = context.Countries.FirstOrDefault(c => c.Id == vm.Id);
			cntry.Name = vm.Name;
			if (vm.Image is not null)
			{
				cntry.Image = vm.Image.Save(_env);
			}
			//context.Countries.Update(cntry);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			var cntry = context.Countries.FirstOrDefault(c => c.Id == id);
			cntry.isDeleted = true;
			context.Countries.Update(cntry);
			context.SaveChanges();
		}
	}
}
