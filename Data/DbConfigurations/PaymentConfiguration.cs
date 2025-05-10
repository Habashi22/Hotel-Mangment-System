using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
	{
		public void Configure(EntityTypeBuilder<Payment> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.HasData(new Payment()
			{
				Id=1,
				PaymentDate=DateTime.Now,
				TransactionId="sadiaosd",
				PaymentMethodId=25,
				status="Confirmed",

			});
		}
	}

}
