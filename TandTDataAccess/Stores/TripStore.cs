using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Stores
{
	public class TripStore : ITripStore
	{
		private readonly IConfiguration _config;
		public TripStore(IConfiguration config)
		{
			_config = config;
		}
		public async Task<IEnumerable<TripDto>> GetTripsByTravelerAsync(string firstName, string lastName)
		{
			var connectionString = _config.GetConnectionString("DefaultConnection");
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				var data = await sqlConnection.QueryAsync("[dbo].[usp_Trip_SelectByTraveler]", new { firstName, lastName }, commandType: CommandType.StoredProcedure);
				return data.Select(d => new TripDto(d.TripId, d.TravelerId, d.DepartureDate, d.ReturnDate));
			}
		}
	}
}
