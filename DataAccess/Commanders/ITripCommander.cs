using System.Threading.Tasks;
using DataAccess.Dtos;

namespace DataAccess.Commanders
{
	public interface ITripCommander
	{
		Task<int> InsertTripAsync(TripDto trip);
	}
}
