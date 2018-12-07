using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandTBusinessProcess.Entities;
using TandTDataAccess.Commanders;
using TandTDataAccess.Stores;
using System.Linq;

namespace TandTBusinessProcess.TripBooking
{
	public class TripBooker : ITripBooker
	{
		private readonly ITravelerStore _travelerStore;
		private readonly ITripStore _tripStore;
		private readonly ITravelerCommander _travelerCommander;
		private readonly ITripCommander _tripCommander;

		public TripBooker(ITravelerStore travelerStore, ITripStore tripStore, ITravelerCommander travelerCommander, ITripCommander tripCommander)
		{
			_travelerStore = travelerStore;
			_tripStore = tripStore;
			_travelerCommander = travelerCommander;
			_tripCommander = tripCommander;
		}

		public async Task<bool> BookTripAsync(Trip trip)
		{
			//Does traveler exist?
			var traveler = await _travelerStore.GetTravelerAsync(trip.FirstName, trip.LastName).ConfigureAwait(false);

			//Insert if not exists
			var travelerId = traveler == null
				? await _travelerCommander.InsertTravelerAsync(trip.FirstName, trip.LastName).ConfigureAwait(false)
				: traveler.Id;

			//Is traveler already booked for a trip during this time frame?
			var isBooked = (await _tripStore.GetTripsByTravelerAsync(trip.FirstName, trip.LastName).ConfigureAwait(false)).Any(t => (trip.DepartureDate >= t.DepartureDate && trip.DepartureDate <= t.ReturnDate) || (trip.ReturnDate >= t.DepartureDate && trip.ReturnDate <= t.ReturnDate));
			if(isBooked)
			{
				throw new InvalidOperationException("A trip is already booked for the requested time frame.");
			}

			//Book it!
			await _tripCommander.InsertTripAsync(new TandTDataAccess.Dtos.TripDto(null, travelerId, trip.DepartureDate, trip.ReturnDate)).ConfigureAwait(false);

			//it's all good, man!
			return true;
		}
	}
}
