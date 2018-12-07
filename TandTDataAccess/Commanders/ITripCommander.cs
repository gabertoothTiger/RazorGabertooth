using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Commanders
{
	public interface ITripCommander
	{
		Task<int> InsertTripAsync(TripDto trip);
	}
}
