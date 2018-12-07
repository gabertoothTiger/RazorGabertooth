using System.Threading.Tasks;
using TandTBusinessProcess.Entities;

namespace TandTBusinessProcess.TripBooking
{
	public interface ITripBooker
	{
		Task<bool> BookTripAsync(Trip trip);
	}
}
