using System;
using System.Threading.Tasks;
using HelloRazorWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TandTDataAccess.Stores;

namespace HelloRazorWorld.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ITravelerStore _travelerStore;
		public IndexModel(ITravelerStore travelerStore)
		{
			_travelerStore = travelerStore;
		}

		public string Message { get; set; } 
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

			var traveler = await _travelerStore.GetTravelerAsync("Gabe", "Schmidt").ConfigureAwait(true);
			
			return RedirectToPage($"/Confirmation", new { departureDate = DateRange.StartDate, returnDate = DateRange.EndDate});
		}
	}
}
