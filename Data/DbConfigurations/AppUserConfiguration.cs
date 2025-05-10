using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			builder.HasData(new AppUser
			{
				Id = "1",
				UserName = "user1",
				NormalizedUserName = "USER1",
				Email = "user1@example.com",
				NormalizedEmail = "USER1@EXAMPLE.COM",
				EmailConfirmed = true,
				PasswordHash = "Password123!",
				SecurityStamp = string.Empty,
				FirstName = "John",
				LastName = "Doe",
				AccessFailedCount = 0,
				//IsBanned = false
			});
		}
	}
}
