using System;
using System.Collections.Generic;
using System.Text;

namespace TandTBusinessProcess.Entities
{
	public class Trip
	{
		public Trip(string firstName, string lastName, DateTime departureDate, DateTime returnDate)
		{
			FirstName = firstName;
			LastName = lastName;
			DepartureDate = departureDate;
			ReturnDate = returnDate;
		}
		public string FirstName { get; }
		public string LastName { get; }
		public DateTime DepartureDate { get; }
		public DateTime ReturnDate { get; }
	}
}
