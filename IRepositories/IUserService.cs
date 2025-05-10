namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface IUserService
	{
		public  Task<AppUser> AddUser(RegisterViewModel vm);
		public  Task AddRole(AppUser user, BookingRole role);
	}
}
