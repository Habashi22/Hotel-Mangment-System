using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{

	public class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new City()
			{
				CountryId = 1,
				Id = 1,
				Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
				Name = "GIZA"
			});
		}
	}

}
