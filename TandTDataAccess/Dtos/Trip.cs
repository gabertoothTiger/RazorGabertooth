using System;
using System.Collections.Generic;
using System.Text;

namespace TandTDataAccess.Dtos
{
	public class Trip
	{
		public int Id { get; }
		public int TravelerId { get; }
		public DateTime DepartureDate { get; }
		public DateTime ReturnDate { get; }
	}
}
