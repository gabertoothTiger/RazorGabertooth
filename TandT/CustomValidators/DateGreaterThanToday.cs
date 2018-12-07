using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TandT.CustomValidators
{
	public class DateGreaterThanToday : ValidationAttribute, IClientModelValidator
	{
		public void AddValidation(ClientModelValidationContext context)
		{
			MergeAttribute(context.Attributes, "data-val", "true");
			var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
			MergeAttribute(context.Attributes, "data-val-dategreaterthantoday", errorMessage);
		}

		private static void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
		{
			if (!attributes.ContainsKey(key))
				attributes.Add(key, value);
		}

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
