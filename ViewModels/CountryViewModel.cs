namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class CountryViewModel
	{
		public int? Id { set; get; }
		public string Name { set; get; }
		[ImageExtension]
		public IFormFile? Image { set; get; }

	}
}
