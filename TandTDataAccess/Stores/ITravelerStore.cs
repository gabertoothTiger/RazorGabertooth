using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Stores
{
	public interface ITravelerStore
	{
		Task<Traveler> GetTravelerAsync(string firstName, string lastName);
	}
}
