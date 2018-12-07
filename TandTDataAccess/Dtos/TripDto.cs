using System;
using System.Collections.Generic;
using System.Text;

namespace TandTDataAccess.Dtos
{
	public class TripDto
	{
		public TripDto(int? id, int travelerId, DateTime departureDate, DateTime returnDate)
		{
			Id = id.HasValue ? id.Value : int.MinValue;
			TravelerId = travelerId;
			DepartureDate = departureDate;
			ReturnDate = returnDate;
		}
		public int Id { get; }
		public int TravelerId { get; }
		public DateTime DepartureDate { get; }
		public DateTime ReturnDate { get; }
	}
}
