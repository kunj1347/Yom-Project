using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class PhotosModel
    {
        public string title { get; set; }

        public string discription { get; set; }

        public IFormFile image { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string title, string discription, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into photos(title , discription ,img)values('" + title + "', '" + discription + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[photos]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

		public int Delete(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from [dbo].[photos] where id = '" + id + "' ", con);
			con.Open();
			return cmd.ExecuteNonQuery();
		}

		public DataSet update(int id)
		{
			SqlCommand cmd = new SqlCommand("select * from [dbo].[photos] where id = '" + id + "' ", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public int update_data(int id, string title, string discription, string filename)
		{
			SqlCommand cmd = new SqlCommand("update [dbo].[photos] set title = '" + title + "',discription = '" + discription + "', img = '" + filename + "' where id = '" + id + "'", con);
			con.Open();

			return cmd.ExecuteNonQuery();
		}

	}
}
