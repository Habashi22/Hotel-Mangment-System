using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Attributes
{
	public class myAgeAttribute:ValidationAttribute //new
	{
		public override bool IsValid(object? value)
		{


			if (value is not null)
			{
				if (value is DateTime date)
				{

					TimeSpan age = DateTime.Now - date;
					if (age.Days < 100*365 && age.Days>=18*365)
					{
						return true;
					}
					else
					{
						ErrorMessage = "You cant add an age that is less than 18 and more than 100";
						return false;
					}
				}

				else
				{
					ErrorMessage = "You Have to add an Age";
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
