using System;
using System.Threading.Tasks;
using TandT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TandTBusinessProcess.TripBooking;
using TandTBusinessProcess.Entities;
using Microsoft.Extensions.Logging;

namespace TandT.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ITripBooker _tripBooker;
		private readonly ILogger _logger;
		public IndexModel(ITripBooker tripBooker, ILogger<IndexModel> logger)
		{
			_tripBooker = tripBooker;
			_logger = logger;
		}

		public string Message { get; set; }
		[BindProperty]
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[BindProperty]
		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[BindProperty]
		public DateRange DateRange { get; set; }

		public async void OnGetAsync()
		{
			Message = "Book your trip";
			if (DateRange == null)
				DateRange = new DateRange();
			DateRange.StartDate = DateTime.Today;
			DateRange.EndDate = DateTime.Today.AddDays(1);
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if(!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				await _tripBooker.BookTripAsync(new Trip(FirstName, LastName, DateRange.StartDate, DateRange.EndDate)).ConfigureAwait(true);
			}
			catch(InvalidOperationException ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				_logger.LogError(ex.Message);
				return Page();
			}
			
			return RedirectToPage($"/Confirmation", new { departureDate = DateRange.StartDate, returnDate = DateRange.EndDate});
		}
	}
}
