using Microsoft.Data.SqlClient;
using System.Data;

namespace TestAPI.Service
{
	public class ProductService
	{


		private readonly IConfiguration _configuration;
		private readonly string _conStr;

		public ProductService(IConfiguration configuration)
		{

			_configuration = configuration;
			_conStr = _configuration.GetConnectionString("DefaultConnection");
		}


		public Task<DataTable> GetDataTableAsync(string sSQL, params SqlParameter[] para)
		{
			return Task.Run(() =>
			{
				using var newCon = new SqlConnection(_conStr);
				using var adapt = new SqlDataAdapter(sSQL, newCon);
				newCon.Open();
				adapt.SelectCommand.CommandType = CommandType.Text;
				if (para != null)
					adapt.SelectCommand.Parameters.AddRange(para);

				DataTable dt = new();
				adapt.Fill(dt);
				newCon.Close();
				return dt;
			});
		}

		public async Task<DataTable> GetProductList()
		{
			string sql = "select * from Product";

			DataTable dt=await GetDataTableAsync(sql);

			return dt;
		}

	}
}
