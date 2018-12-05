using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HelloRazorWorld.CustomValidators
{
	public class DateGreaterThan : ValidationAttribute
	{
		private readonly string _startDatePropertyName;
		public DateGreaterThan(string startDatePropertyName)
		{
			_startDatePropertyName = startDatePropertyName;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{						
			var propertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);
			if (propertyInfo == null)
			{
				return new ValidationResult(string.Format("Unknown property {0}", _startDatePropertyName));
			}
			var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
			if ((DateTime)value > (DateTime)propertyValue)
			{
				return ValidationResult.Success;
			}
			else
			{
				var startDateDisplayName = propertyInfo
					.GetCustomAttributes(typeof(DisplayAttribute), true)
					.Cast<DisplayAttribute>()
					.Single()
					.Name;
				return new ValidationResult(validationContext.DisplayName + " must be later than " + startDateDisplayName + ".");
			}
		}
	}
}
