using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Dtos;

namespace DataAccess.Stores
{
	public interface ITripStore
	{
		Task<IEnumerable<TripDto>> GetTripsByTravelerAsync(string firstName, string lastName);
	}
}
