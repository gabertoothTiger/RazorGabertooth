using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Commanders
{
	public interface ITravelerCommander
	{
		Task<int> InsertTravelerAsync(string firstName, string lastName);
	}
}
