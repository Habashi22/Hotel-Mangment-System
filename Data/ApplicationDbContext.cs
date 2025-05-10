using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Data.DbConfigurations;
using MVCBookingFinal_YARAB_.Models;
using System.Reflection.Emit;
using MVCBookingFinal_YARAB_.ViewModels;

namespace MVCBookingFinal_YARAB_.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
	
	public virtual DbSet<Amenity> Amenities { set; get; }
	public virtual DbSet<City> Cities { set; get; }
	public virtual DbSet<Country> Countries { set; get; }
	public virtual DbSet<DraftReservation> DraftReservations { set; get; }
	public virtual DbSet<Favorite> Favorites { set; get; }
	public virtual DbSet<Hotel> Hotels { set; get; }
	public virtual DbSet<Invoice> Invoices { set; get; }
	public virtual DbSet<MealPlan> MealPlans { set; get; }
	public virtual DbSet<Payment> Payments { set; get; }
	public virtual DbSet<CardPaymentMethod> CardPaymentMethods { set; get; }
	public virtual DbSet<StripePaymentMethod> StripePaymentMethod { set; get; }
	public virtual DbSet<PromoCode> PromoCodes { set; get; }
	public virtual DbSet<Report> Reports { set; get; }
	public virtual DbSet<Reservation> Reservations { set; get; }
	public virtual DbSet<ReservationRoom> ReservationRooms { set; get; }
	public virtual DbSet<Review> Reviews { set; get; }
	public virtual DbSet<Room> Rooms { set; get; }
	public virtual DbSet<UsedPromoCodes> UsedPromoCodes { set; get; }
	public virtual DbSet<AppUser> Users { set; get; }
	public virtual DbSet<HotelImage> HotelsImages { set; get; }
	public virtual DbSet<AppUser> AppUsersss { set; get; }
	public virtual DbSet<RoomImage> RoomsImages { set; get; }
	public virtual DbSet<DraftReservationRoom> DraftReservationRoom { set; get; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
		//_roleManager = roleManager;
	}
	//private readonly RoleManager<IdentityRole> _roleManager;
	 protected  override void OnModelCreating(ModelBuilder builder)
	{
		//builder.Entity<DraftReservationRoom>().HasKey(r => new { r.ReservedId, r.DraftReservationId });
		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			foreach (var foreignKey in entityType.GetForeignKeys())
			{
				foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}

		//builder.Entity<AppUser>().HasData(new AppUser
		//{
		//	Id = "1",
		//	UserName = "user1",
		//	NormalizedUserName = "USER1",
		//	Email = "user1@example.com",
		//	NormalizedEmail = "USER1@EXAMPLE.COM",
		//	EmailConfirmed = true,
		//	PasswordHash = "Password123!",
		//	SecurityStamp = string.Empty,
		//	FirstName = "John",
		//	LastName = "Doe",
		//	AccessFailedCount = 0,
		//	//IsBanned = false
		//});
		//builder.ApplyConfiguration(new AppUserConfiguration());
		//builder.ApplyConfiguration(new CountryConfiguration());
		//builder.ApplyConfiguration(new CityConfiguration());
		//builder.ApplyConfiguration(new AmenityConfiguration());
		//builder.ApplyConfiguration(new MealPlanConfiguration());
		//builder.ApplyConfiguration(new CardPaymentMethodConfiguration());
		//builder.ApplyConfiguration(new HotelConfiguration());
		//builder.ApplyConfiguration(new HotelImageConfiguration());
		//builder.ApplyConfiguration(new ReservationConfiguration());
		//builder.ApplyConfiguration(new RoomConfiguration());
		//builder.ApplyConfiguration(new RoomImageConfiguration());
		//builder.ApplyConfiguration(new ReservationRoomConfiguration());
		//builder.ApplyConfiguration(new ReviewConfiguration());
		//builder.ApplyConfiguration(new ReportConfiguration());
		//builder.ApplyConfiguration(new FavoriteConfiguration());
		//builder.ApplyConfiguration(new StripePaymentMethodConfiguration());
		//builder.ApplyConfiguration(new PaymentConfiguration());
		//builder.ApplyConfiguration(new InvoiceConfiguration());
		//builder.ApplyConfiguration(new PromoCodeConfiguration());
		//builder.ApplyConfiguration(new UsedPromoCodesConfiguration());
		//builder.ApplyConfiguration(new DraftReservationConfiguration());
		//builder.ApplyConfiguration(new RoleConfiguration());
		builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		builder.Entity<IdentityRole>().HasData(SeedRoles());

		//SeedAll(builder);
		base.OnModelCreating(builder);
	}
	void SeedAll(ModelBuilder builder)
	{
		builder.Entity<AppUser>().HasData(new AppUser
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
		builder.Entity<Amenity>().HasData(new Amenity()
		{
			//builder.Property(h => h.).HasDefaultValue(false);
			Amenities = AmenityEnum.SwimmingPool | AmenityEnum.Laundry | AmenityEnum.ExtraRoomService,
			Id = 1,
		});
		builder.Entity<IdentityRole>().HasData(SeedRoles());

		builder.Entity<Country>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<Country>().HasData(new Country()
		{
			Id = 1,
			Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
			Name = "Egypt"
		});

		builder.Entity<City>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<City>().HasData(new City()
		{
			CountryId = 1,
			Id = 1,
			Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
			Name = "GIZA"
		});

		builder.Entity<MealPlan>().HasData(new List<MealPlan>()
			{
				new MealPlan{plan = mealPlan.Lunch,
				Id = 1 },
				new MealPlan{plan = mealPlan.BreakfastAndDinner,
				Id = 2 },
				new MealPlan{plan = mealPlan.AllInclusive,
				Id = 3 },

			}
			);


		builder.Entity<Hotel>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<Hotel>().HasData(new Hotel()
		{
			Address = "125 GIZA",
			CityId = 1,
			id = 1,
			AmenetiesId = 1,
			Description = "big hotel",
			Email = "placahotel@gmail.com",
			starRating = 4,
			PhoneNumber = "01143874387",

			Name = "PlazaHotel"
		});


		builder.Entity<HotelImage>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<HotelImage>().HasData(new HotelImage
		{
			HotelId = 1,
			Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
			Id = 1
		});

		
		builder.Entity<Room>().Property(h => h.Status).HasDefaultValue(RoomStatus.Available);
		builder.Entity<Room>().HasData(new List<Room>()
			{
				new Room{
				Id = 1 ,
				HotelId=1,
				//Capacity=5,
				Floor=2,
				PricePerNight=5000,
				roomType=RoomType.Single,
				//Status=RoomStatus.Available
				},
			});


		builder.Entity<RoomImage>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<RoomImage>().HasData(new RoomImage
		{
			roomId = 1,
			Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
			Id = 1
		});


		builder.Entity<Review>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<Review>().HasData(new Review()
		{

			Id = 1,
			HotelId = 1,
			UserId = "1",
			Description = "thank you for the hotel",
			Rating = 5,
			ReviewDate = DateTime.Now,

		});

		builder.Entity<Report>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<Report>().HasData(new Report()
		{

			Id = 1,
			HotelId = 1,
			UserId = "1",
			Complaint = "bad food",
			ReviewDate = DateTime.Now,

		});


		builder.Entity<Favorite>().HasData(new Favorite()
		{

			Id = 1,
			HotelId = 1,
			UserId = "1",


		});

		builder.Entity<Reservation>().Property(h => h.reservationStatus).HasDefaultValue(ReservationStatus.Pending);
		builder.Entity<Reservation>().HasData(new Reservation()
		{
			AmenityId = 1,
			Id = 1,
			mealPlanId = 1,
			CheckInDate = DateTime.Now,
			CheckOutDate = DateTime.Now.AddDays(5),

		});


		builder.Entity<ReservationRoom>().Property(h => h.IsDeleted).HasDefaultValue(false);
		builder.Entity<ReservationRoom>().HasData(new ReservationRoom()
		{
			ReservationId = 1,
			RoomId = 1,
			UserId = "1",
		});

		builder.Entity<CardPaymentMethod>().HasData(new CardPaymentMethod()
		{
			Id = 1,

			CardNumber = "5151515",
			CVV = "332",
			ExpiryDate = DateOnly.FromDateTime(DateTime.Now).AddYears(3),
			PaymentType = PaymentType.Card,
		});


		builder.Entity<Payment>().HasData(new Payment()
		{
			Id = 1,
			PaymentDate = DateTime.Now,
			TransactionId = "sadiaosd",
			PaymentMethodId = 1,


		});

		builder.Entity<Invoice>().Property(h => h.isDeleted).HasDefaultValue(false);
		builder.Entity<Invoice>().HasData(new Invoice()
		{
			Id = 1,
			ReservationId = 1,
			Tax = 10,

			PaymentId = 1,
		});


	}
	public List<IdentityRole> SeedRoles()
	{
		return new List<IdentityRole>()
		{
			new IdentityRole { Id ="1d109be1-7c25-4f22-91d7-6e8aa3c60c3e", ConcurrencyStamp = "1d109be1-7c25-4f22-91d7-6e8aa3c60c3e", Name = "User".ToUpper(), NormalizedName = "User".ToUpper() },
			new IdentityRole { Id = "2e209de2-8d45-4f33-92f8-7f9bb4d70d4f", ConcurrencyStamp = "2e209de2-8d45-4f33-92f8-7f9bb4d70d4f", Name = "Admin".ToUpper(), NormalizedName = "Admin".ToUpper() }
		};
	}

public DbSet<MVCBookingFinal_YARAB_.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;

public DbSet<MVCBookingFinal_YARAB_.ViewModels.ReviewViewModel> ReviewViewModel { get; set; } = default!;

}
