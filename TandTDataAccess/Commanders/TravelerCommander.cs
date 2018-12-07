using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Linq;

namespace TandTDataAccess.Commanders
{
	public class TravelerCommander : ITravelerCommander
	{
		private readonly IConfiguration _configuration;
		public TravelerCommander(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<int> InsertTravelerAsync(string firstName, string lastName)
		{
			using (var sqlConn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				return (await sqlConn.QueryAsync<int>("[dbo].[usp_Traveler_Insert]", new { firstName, lastName }, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();
			}
		}
	}
}
