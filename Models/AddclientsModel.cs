using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
	public class AddclientsModel
	{

        public IFormFile image { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert( string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into clients(image)values('" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[clients]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[clients] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update_c(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[clients] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_image_c(int id, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[clients] set image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
    }
}
