using HelloRazorWorld.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace HelloRazorWorld.Models
{
	public class DateRange
	{
		[Display(Name = "Departure Date")]
		[DataType(DataType.Date)]
		[DateGreaterThanToday]
		public DateTime StartDate { get; set; }

		[Display(Name = "Return Date")]
		[DataType(DataType.Date)]
		[DateGreaterThan("StartDate")]
		public DateTime EndDate { get; set; }
	}
}
