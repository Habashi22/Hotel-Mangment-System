
using Microsoft.AspNetCore.Identity;

namespace MVCBookingFinal_YARAB_.Repositories
{
	public class UserService(IWebHostEnvironment env,UserManager<AppUser> _usermanager) : IUserService
	{
		public async Task<AppUser> AddUser(RegisterViewModel vm)
		{
			AppUser user = new()
			{
				Email = vm.Email,
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				UserName = vm.UserName,
				DateOfBirth = vm.DateOfBirth,
				CreationDate = DateTime.Now,
				PhoneNumber = vm.PhoneNumber,
				ProfilePicture = vm.ProfilePicture?.Save(env)
				
			};

			return user;
		}
		public async Task AddRole(AppUser user, BookingRole role)
		{
			switch (role)
			{
				case BookingRole.admin:
				await _usermanager.AddToRoleAsync(user, Roles.Admin.ToUpper());
				break;
				case BookingRole.user:
				await _usermanager.AddToRoleAsync(user, Roles.user.ToUpper());
				break;
				default :
				await _usermanager.AddToRoleAsync(user, Roles.user.ToUpper());
				break;
			}
		}
	}
	public enum BookingRole
	{
		user,
		admin
	}
}
