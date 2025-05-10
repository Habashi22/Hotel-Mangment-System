using System.IO;

namespace MVCBookingFinal_YARAB_.Helpers
{
	public static class SaveImage
	{
		public static string Save(this IFormFile file, IWebHostEnvironment _webHostEnvironment)
		{
			var covername = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
			string thePath = Path.Combine($"{_webHostEnvironment.WebRootPath}{ImageSettings.ImagesPath}", covername);
			using (var stream = System.IO.File.Create(thePath))
			{
				file.CopyTo(stream);
			}
			return covername;
		}	
	}
}
