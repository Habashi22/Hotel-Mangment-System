using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppMVCBookingFinal_YARAB_lication2.Repositories;
using Microsoft.Owin.Security.Google;
using Microsoft.Extensions.Options;
using Stripe8.Models;
namespace MVCBookingFinal_YARAB_
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			//builder.Services.AddSession();

			builder.Services.AddControllersWithViews();

			#region Services
			builder.Services.AddSingleton<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();

			builder.Services.AddDbContext<ApplicationDbContext>(OP => OP.UseSqlServer(
				builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging()
			  .LogTo(Console.WriteLine, LogLevel.Information));
			builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

			builder.Services.AddAuthentication(
				options =>
				{
					options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				}
				).AddCookie().AddGoogle(OP =>
				{
					OP.ClientId = "901762703796-bdhr0q34es72k49j1jjtruit0kplovib.apps.googleusercontent.com";
					OP.ClientSecret = "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";

				}).AddFacebook(op =>
				{
					op.AppId = "1341703253547842";
					op.AppSecret = "9b2593ba5d2a3d86957ec93831791298";
				});

			builder.Services.AddHttpContextAccessor();

			builder.Services.AddScoped<AuthorFilter>();
			builder.Services.AddScoped<AuthorAndAdminFilter>();

			builder.Services.AddScoped<ICountryService, CountryService>(); 
			builder.Services.AddScoped<IUserService, UserService>(); 
			builder.Services.AddScoped<IHotelService, HotelService>(); 
			builder.Services.AddScoped<ICityService, CityService>(); 
			builder.Services.AddScoped<IRoomService, RoomService>(); 
			builder.Services.AddScoped<IReservationRoom, ReservationRoomService>(); 
			builder.Services.AddScoped<IReportService, ReportService>(); 
			builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>(); 
			builder.Services.AddScoped<IFavoritesService, FavoritesService>(); 
			builder.Services.AddScoped<IPaymentService, PaymentService>(); 
			builder.Services.AddScoped<IPromoCodeService, PromoCodeService>();
			builder.Services.AddScoped<IReviewsService, ReviewsService>();
			builder.Services.AddScoped<IInvoiceService, InvoiceService>();
			builder.Services.AddScoped<IUsedPromoCodeService, UsedPromoCodeService>();
			builder.Services.AddScoped<IReservationService, ReservationService>();
			builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

			builder.Services.AddScoped<IEmailSettings, EmailSettings>();

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.SignIn.RequireConfirmedEmail = true; // Prevent login without email confirmation
			});


			builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));
			var key = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");
			//builder.Services.AddScoped<Iused, FavoritesService>(); 
			#endregion
			var app = builder.Build();
			bool isFirstRequest = true;
			app.Use(async (context, next) =>
			{
				// Clear TempData cookies on every request
				if (isFirstRequest)
				{
					context.Response.Cookies.Delete(".AspNetCore.TempData"); // Clear TempData cookie
					isFirstRequest = false;
				}
				await next.Invoke();
			});

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
