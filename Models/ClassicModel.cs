using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
	public class ClassicModel
	{
		public string title { get; set; }

		public string name { get; set; }

		public string date { get; set; }

		public string cat { get; set; }

		public string discription { get; set; }

		public IFormFile image { get; set; }


		SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


		public int insert(string title, string name, string date, string cat, string discription, string filename)
		{
			SqlCommand cmd = new SqlCommand("insert into classic(title , name , date , cat  , discription ,image)values('" + title + "', '" + name + "','" + date + "' , '" + cat + "', '" + discription + "','" + filename + "')", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
		public DataSet select()
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[classic]", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[classic] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}

		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[classic] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_data(int id, string title, string name, string date, string cat, string discription, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[classic] set title = '" + title + "',name = '" + name + "' , date = '" + date + "', cat = '" + cat + "',discription = '" + discription + "', image = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}
	}
}
