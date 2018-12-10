using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dtos;

namespace DataAccess.Stores
{
	public interface ITravelerStore
	{
		Task<TravelerDto> GetTravelerAsync(string firstName, string lastName);
	}
}
