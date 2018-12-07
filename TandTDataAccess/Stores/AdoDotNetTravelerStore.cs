using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TandTDataAccess.Dtos;
using System.Linq;

namespace TandTDataAccess.Stores
{
	public class AdoDotNetTravelerStore : ITravelerStore
	{
		private readonly IConfiguration _config;
		public AdoDotNetTravelerStore(IConfiguration config)
		{
			_config = config;
		}

		public async Task<TravelerDto> GetTravelerAsync(string firstName, string lastName)
		{
			var connectionString = _config.GetConnectionString("DefaultConnection");
			using (var conn = new SqlConnection(connectionString))
			{
				await conn.OpenAsync();				
				SqlCommand cmd = new SqlCommand("[dbo].[usp_Traveler_Select]", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@FirstName", firstName);
				cmd.Parameters.AddWithValue("@LastName", lastName);
				var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

				var travelerList = new List<TravelerDto>();
				while(await reader.ReadAsync())
				{
					travelerList.Add(new TravelerDto((int)reader["Id"], reader["FirstName"].ToString(), reader["LastName"].ToString()));					
				}
				return travelerList.FirstOrDefault();
			}
		}
	}
}
