using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TandT.Pages
{
	public class ConfirmationModel : PageModel
	{
		public DateTime DepartureDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public void OnGet(DateTime departureDate, DateTime returnDate)
        {
			DepartureDate = departureDate;
			ReturnDate = returnDate;
        }
    }
}