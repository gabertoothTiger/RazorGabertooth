using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TandT.CustomValidators
{
	public class DateGreaterThan : ValidationAttribute, IClientModelValidator
	{
		private readonly string _startDatePropertyName;
		public DateGreaterThan(string startDatePropertyName)
		{
			_startDatePropertyName = startDatePropertyName;
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			MergeAttribute(context.Attributes, "data-val", "true");
			var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
			MergeAttribute(context.Attributes, "data-val-dategreaterthan", errorMessage);
			MergeAttribute(context.Attributes, "data-val-dategreaterthan-other", _startDatePropertyName);
		}


		private static void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
		{
			if (!attributes.ContainsKey(key))
				attributes.Add(key, value);
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
