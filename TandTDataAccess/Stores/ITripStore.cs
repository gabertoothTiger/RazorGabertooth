using System.Collections.Generic;
using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Stores
{
	public interface ITripStore
	{
		Task<IEnumerable<TripDto>> GetTripsByTravelerAsync(string firstName, string lastName);
	}
}
