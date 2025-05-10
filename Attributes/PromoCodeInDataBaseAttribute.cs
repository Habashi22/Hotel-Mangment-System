
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Attributes
{
	public class PromoCodeInDataBaseAttribute:ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var _context = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			if (value is not null)
			{
				if (value is not string)
				{
					return new ValidationResult("Only string is allowed.");

				}
				else
				{
					if (!_context.PromoCodes.Any(p=>p.Code==value))
					{
						return new ValidationResult("Promo code is invalid.");

					}
				}
			}
			return ValidationResult.Success;
		}
	}
}
