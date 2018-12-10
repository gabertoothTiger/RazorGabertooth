using System.Threading.Tasks;
using BusinessProcess.Entities;

namespace BusinessProcess.TripBooking
{
	public interface ITripBooker
	{
		Task<bool> BookTripAsync(Trip trip);
	}
}
