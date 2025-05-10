using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class CardPaymentMethodConfiguration : IEntityTypeConfiguration<CardPaymentMethod>
	{
		public void Configure(EntityTypeBuilder<CardPaymentMethod> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.HasData(new CardPaymentMethod()
			{
				Id = 25,

				CardNumber="5151515",
				CVV="332",
				ExpiryDate= DateOnly.FromDateTime(DateTime.Now).AddYears(3),
				PaymentType=PaymentType.Card,
			});
		}
	}

}
