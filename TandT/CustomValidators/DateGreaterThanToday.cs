using System;
using System.ComponentModel.DataAnnotations;

namespace HelloRazorWorld.CustomValidators
{
	public class DateGreaterThanToday : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{						
			if ((DateTime)value >= DateTime.Today)
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult(validationContext.DisplayName + " must be today or later.");
			}
		}
	}
}
