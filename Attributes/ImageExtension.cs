using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Attributes
{
	public class ImageExtensionAttribute:ValidationAttribute
	{
		public override bool IsValid(object? value)
		{


			if (value is not null)
			{
					string Allowedextensions = ImageSettings.AllowedExtensions;
				if (value is IFormFile file)
				{
					string extension = Path.GetExtension(file.FileName);
					if (Allowedextensions.ToLower().Split(",").Contains(extension.ToLower()))
					{
						return true;
					}
					else
					{
						ErrorMessage = "You can only add .jpg,.jpeg,.png,.bmp,.gif,.svg,.webp,.avif,.apng files";
						return false;
					}
				}
				if(value is IEnumerable<IFormFile> files)
				{
					foreach (var thefile in files)
					{
					string extension = Path.GetExtension(thefile.FileName);
						if (Allowedextensions.ToLower().Split(",").Contains(extension.ToLower()))
						{
							
						}
						else
						{
							ErrorMessage = "You can only add .jpg,.jpeg,.png,.bmp,.gif,.svg,.webp,.avif,.apng files";
							return false;
						}
					}
					return true;
				}

				else
				{
					ErrorMessage = "You Have to add an image";
					return false;
				}
			}
			else
			{
				return true;
			}


		}
	}
}
