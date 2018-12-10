using RazorGabertooth.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorGabertooth.Models
{
	public class DateRange
	{
		[Display(Name = "Departure Date")]
		[DataType(DataType.Date)]
		[DateGreaterThanToday(ErrorMessage = "Date must be today or later.")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Return Date")]
		[DataType(DataType.Date)]
		[DateGreaterThan("StartDate", ErrorMessage = "Return Date must be later than Departure Date")]
		public DateTime EndDate { get; set; }
	}
}
