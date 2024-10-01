using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
	public class WorksliderModsel
	{

		public IFormFile image { get; set; }

		public string tempdata { get; set; }

		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


		public int insert( string filename)
		{
			SqlCommand cmd = new SqlCommand("insert into work_slider(image)values('" + filename + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[work_slider]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[work_slider] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}


		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[work_slider] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_data(int id,  string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[work_slider] set image = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
