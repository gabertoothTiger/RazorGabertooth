using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TandTDataAccess.Dtos;

namespace TandTDataAccess.Commanders
{
	public class TripCommander : ITripCommander
	{
		private readonly IConfiguration _configuration;
		public TripCommander(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<int> InsertTripAsync(TripDto trip)
		{
			using (var sqlConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				return (await sqlConn.QueryAsync<int>("[dbo].[usp_Trip_Insert]", new { trip.TravelerId, trip.DepartureDate, trip.ReturnDate }, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();
			}
		}
	}
}
