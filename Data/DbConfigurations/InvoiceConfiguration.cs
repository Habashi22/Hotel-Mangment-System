using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
	{
		public void Configure(EntityTypeBuilder<Invoice> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new Invoice()
			{
				Id=1,
				ReservationId=1,
				Tax=10,
				
				PaymentId=1,
			});
		}
	}

}
