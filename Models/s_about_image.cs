using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class s_about_image
    {
        public string title { get; set; }

        public string discription1 { get; set; }

        public string discription2 { get; set; }

        public IFormFile image { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string title, string discription1, string discription2, string filename)
        {
            SqlCommand cmd = new SqlCommand("insert into s_about_image(title , discription1 ,discription2,image)values('" + title + "', '" + discription1 + "', '" + discription2 + "','" + filename + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[s_about_image]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[s_about_image] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }


        public DataSet update_a(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[s_about_image] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data_a(int id, string title, string discription1, string discription2, string filename)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[s_about_image] set title = '" + title + "',discription1 = '" + discription1 + "', discription2 = '" + discription2 + "', image = '" + filename + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

    }
}
