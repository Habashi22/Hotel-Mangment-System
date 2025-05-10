using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MVCBookingFinal_YARAB_.Attributes
{
	public class DateGreaterThanAttribute: ValidationAttribute
	{
		private readonly DateTime _comparedto;

		public DateGreaterThanAttribute(DateTime comparedto)
		{
			_comparedto = comparedto;

		}
		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null || !(value is DateTime currentDate))
			{
				return new ValidationResult("The current date must be a valid DateTime.");
			}

			
			
			if (currentDate <= _comparedto)
			{
				return new ValidationResult(ErrorMessage);
			}

			// If everything is valid, return Success
			return ValidationResult.Success;
		}
	}
}
