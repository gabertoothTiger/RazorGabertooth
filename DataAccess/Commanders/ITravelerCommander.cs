using System.Threading.Tasks;

namespace DataAccess.Commanders
{
	public interface ITravelerCommander
	{
		Task<int> InsertTravelerAsync(string firstName, string lastName);
	}
}
