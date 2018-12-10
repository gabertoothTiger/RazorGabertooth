using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataAccess.Dtos;
using Dapper;
using System.Data;
using System.Linq;

namespace DataAccess.Stores
{
	public class TravelerStore : ITravelerStore
	{
		private readonly IConfiguration _config;
		public TravelerStore(IConfiguration config)
		{
			_config = config;
		}

		public async Task<TravelerDto> GetTravelerAsync(string firstName, string lastName)
		{
			var connectionString = _config.GetConnectionString("DefaultConnection");
			using (var sqlConnection = new SqlConnection(connectionString))
			{
				var data = await sqlConnection.QueryAsync("[dbo].[usp_Traveler_Select]", new { firstName, lastName }, commandType: CommandType.StoredProcedure);
				return data.Select(d => new TravelerDto(d.Id, d.FirstName, d.LastName)).FirstOrDefault();
			}
		}
	}
}
