using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
	public class ClientsModel
	{

		public IFormFile image { get; set; }

		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


		public int insert(string filename)
		{
			SqlCommand cmd = new SqlCommand("insert into clients_a(image)values('" + filename + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[clients_a]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[clients_a] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}

		public DataSet update_c(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[clients_a] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_image_c(int id, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[clients_a] set image = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}

